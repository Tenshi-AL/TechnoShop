using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TechnoShop.DTO;

namespace TechnoShop.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcessorController(IProcessorService processorService, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Method return processor list.
    /// </summary>
    [HttpGet("List")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> List([FromQuery] ProcessorQueryParams parameters, CancellationToken cancellationToken)
    {
        var list = await processorService.List(parameters, cancellationToken);
        var result = mapper.Map<List<ProcessorReadDto>>(list);
        return Ok(new
        {
            result,
            parameters.PageSize,
            parameters.Page,
        });
    }

    /// <summary>
    /// Return processor instance
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var processor = await processorService.Get(id, cancellationToken);
        if (processor is null) return NotFound();
        var result = mapper.Map<ProcessorReadDto>(processor);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Post([FromBody] ProcessorWriteDto processorWriteDto, CancellationToken cancellationToken)
    {
        var processor = mapper.Map<Processor>(processorWriteDto);
        var result = await processorService.Create(processor, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    /// <summary>
    /// Edit processor 
    /// </summary>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Patch(Guid id, JsonPatchDocument<ProcessorWriteDto> jsonPatchDocument,
        CancellationToken cancellationToken)
    {
        var processor = await processorService.Get(id, cancellationToken);
        if (processor is null) return NotFound();
        
        var processorPatchDocument = mapper.Map<JsonPatchDocument<Processor>>(jsonPatchDocument);
        processorPatchDocument.ApplyTo(processor);

        var result = await processorService.Update(processor, cancellationToken);
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