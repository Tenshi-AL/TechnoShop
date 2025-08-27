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
public class SSDController(ISSDService ssdService, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Method return SSD list.
    /// </summary>
    [HttpGet("List")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> List([FromQuery] SSDQueryParameters parameters, CancellationToken cancellationToken)
    {
        var list = await ssdService.List(cancellationToken);
        var mappedList = mapper.Map<List<SsdReadDto>>(list
            .Filter(parameters)
            .Order(parameters));
        return Ok(new ListResponce<SsdReadDto>(mappedList, parameters.Page, parameters.PageSize));
    }

    /// <summary>
    /// Return SSD instance
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var ssd = await ssdService.Get(id, cancellationToken);
        if (ssd is null) return NotFound();
        var result = mapper.Map<SsdReadDto>(ssd);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Post([FromBody] SsdWriteDto ssdWriteDto, CancellationToken cancellationToken)
    {
        var ssd = mapper.Map<SSD>(ssdWriteDto);
        var result = await ssdService.Create(ssd, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    /// <summary>
    /// Edit SSD 
    /// </summary>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Patch(Guid id, JsonPatchDocument<SsdWriteDto> jsonPatchDocument,
        CancellationToken cancellationToken)
    {
        var ssd = await ssdService.Get(id, cancellationToken);
        if (ssd is null) return NotFound();
        
        var ssdPatchDocument = mapper.Map<JsonPatchDocument<SSD>>(jsonPatchDocument);
        ssdPatchDocument.ApplyTo(ssd);

        var result = await ssdService.Update(ssd, cancellationToken);
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