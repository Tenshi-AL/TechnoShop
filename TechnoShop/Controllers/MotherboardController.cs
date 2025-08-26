using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TechnoShop.DTO;

namespace TechnoShop.Controllers;

[ApiController]
[Route("[controller]")]
public class MotherboardController(IMotherboardService motherboardService, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Method return motherboard list.
    /// </summary>
    [HttpGet("List")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> List([FromQuery] MotherboardQueryParameters parameters, CancellationToken cancellationToken)
    {
        var list = await motherboardService.List(parameters, cancellationToken);
        var result = mapper.Map<List<MotherboardReadDto>>(list);
        return Ok(new
        {
            result,
            parameters.PageSize,
            parameters.Page,
        });
    }

    /// <summary>
    /// Return motherboard instance
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var motherboard = await motherboardService.Get(id, cancellationToken);
        if (motherboard is null) return NotFound();
        var result = mapper.Map<MotherboardReadDto>(motherboard);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Post([FromBody] MotherboardWriteDto motherboardWriteDto, CancellationToken cancellationToken)
    {
        var motherboard = mapper.Map<Motherboard>(motherboardWriteDto);
        var result = await motherboardService.Create(motherboard, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    /// <summary>
    /// Edit motherboard 
    /// </summary>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Patch(Guid id, JsonPatchDocument<MotherboardWriteDto> jsonPatchDocument,
        CancellationToken cancellationToken)
    {
        var motherboard = await motherboardService.Get(id, cancellationToken);
        if (motherboard is null) return NotFound();
        
        var motherboardPatchDocument = mapper.Map<JsonPatchDocument<Motherboard>>(jsonPatchDocument);
        motherboardPatchDocument.ApplyTo(motherboard);

        var result = await motherboardService.Update(motherboard, cancellationToken);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}