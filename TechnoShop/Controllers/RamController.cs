using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TechnoShop.DTO;
using TechnoShop.Extensions;
using TechnoShop.Models;

namespace TechnoShop.Controllers;

[ApiController]
[Route("[controller]")]
public class RamController(IRAMService ramService, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Method return RAM list.
    /// </summary>
    [HttpGet("List")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> List([FromQuery] RAMQueryParameters parameters, CancellationToken cancellationToken)
    {
        var list = await ramService.List(cancellationToken);
        var mappedList = mapper.Map<List<RamReadDto>>(list
            .Filter(parameters)
            .Order(parameters));
        return Ok(new ListResponce<RamReadDto>(mappedList, parameters.Page, parameters.PageSize));
    }

    /// <summary>
    /// Return RAM instance
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var ram = await ramService.Get(id, cancellationToken);
        if (ram is null) return NotFound();
        var result = mapper.Map<RamReadDto>(ram);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Post([FromBody] RamWriteDto ramWriteDto, CancellationToken cancellationToken)
    {
        var ram = mapper.Map<RAM>(ramWriteDto);
        var result = await ramService.Create(ram, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    /// <summary>
    /// Edit RAM 
    /// </summary>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Patch(Guid id, JsonPatchDocument<RamWriteDto> jsonPatchDocument,
        CancellationToken cancellationToken)
    {
        var ram = await ramService.Get(id, cancellationToken);
        if (ram is null) return NotFound();
        
        var ramPatchDocument = mapper.Map<JsonPatchDocument<RAM>>(jsonPatchDocument);
        ramPatchDocument.ApplyTo(ram);

        var result = await ramService.Update(ram, cancellationToken);
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