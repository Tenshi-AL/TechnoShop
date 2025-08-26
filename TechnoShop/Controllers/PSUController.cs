using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TechnoShop.DTO;

namespace TechnoShop.Controllers;

[ApiController]
[Route("[controller]")]
public class PSUController(IPSUService psuService, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Method return PSU list.
    /// </summary>
    [HttpGet("List")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> List([FromQuery] PSUQueryParameters parameters, CancellationToken cancellationToken)
    {
        var list = await psuService.List(parameters, cancellationToken);
        var result = mapper.Map<List<PsuReadDto>>(list);
        return Ok(new
        {
            result,
            parameters.PageSize,
            parameters.Page,
        });
    }

    /// <summary>
    /// Return PSU instance
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var psu = await psuService.Get(id, cancellationToken);
        if (psu is null) return NotFound();
        var result = mapper.Map<PsuReadDto>(psu);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Post([FromBody] PsuWriteDto psuWriteDto, CancellationToken cancellationToken)
    {
        var psu = mapper.Map<PSU>(psuWriteDto);
        var result = await psuService.Create(psu, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    /// <summary>
    /// Edit PSU 
    /// </summary>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Patch(Guid id, JsonPatchDocument<PsuWriteDto> jsonPatchDocument,
        CancellationToken cancellationToken)
    {
        var psu = await psuService.Get(id, cancellationToken);
        if (psu is null) return NotFound();
        
        var psuPatchDocument = mapper.Map<JsonPatchDocument<PSU>>(jsonPatchDocument);
        psuPatchDocument.ApplyTo(psu);

        var result = await psuService.Update(psu, cancellationToken);
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