using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TechnoShop.DTO;
using TechnoShop.Extensions;
using TechnoShop.Models;

namespace TechnoShop.Controllers;

//TODO Controller must be with [Auth] attribute

[ApiController]
[Route("[controller]")]
public class GpuController(IGpuService gpuService, IMapper mapper): ControllerBase
{
    /// <summary>
    /// Method return gpu list.
    /// </summary>
    /// <param name="parameters">Filtration, order and pagination parameters</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>GPU list</returns>
    [HttpGet("List")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> List([FromQuery] GpuQueryParameters parameters, CancellationToken cancellationToken)
    {
        var list = await gpuService.List(cancellationToken);
        var mappedList = mapper.Map<List<GpuReadDto>>(list
            .Filter(parameters)
            .Order(parameters));
        return Ok(new ListResponce<GpuReadDto>(mappedList, parameters.Page, parameters.PageSize));
    }

    /// <summary>
    /// Return gpu instance
    /// </summary>
    /// <param name="id">GPU id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>GPU instance</returns>
    [HttpGet(":id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var gpu = await gpuService.Get(id, cancellationToken);
        if (gpu is null) return NotFound();
        var result = mapper.Map<GpuReadDto>(gpu);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Post([FromBody] GpuWriteDto gpuWriteDto, CancellationToken cancellationToken)
    {
        var gpu = mapper.Map<GPU>(gpuWriteDto);
        var result = await gpuService.Create(gpu, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    /// <summary>
    /// Edit gpu 
    /// </summary>
    /// <param name="id">GPU id</param>
    /// <param name="jsonPatchDocument">Json patch document</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     [
    ///         {
    ///             "op": "replace",
    ///             "path": "/GPUModel",
    ///             "value": "TEST patch"
    ///         },
    ///     ]
    ///
    /// </remarks>
    /// <returns>Guid id edited gpu</returns>
    [HttpPatch(":id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Patch([FromQuery] Guid id, JsonPatchDocument<GpuWriteDto> jsonPatchDocument,
        CancellationToken cancellationToken)
    {
        var gpu = await gpuService.Get(id, cancellationToken);
        if (gpu is null) return NotFound();
        var gpuPatchDocument = mapper.Map<JsonPatchDocument<GPU>>(jsonPatchDocument);
        gpuPatchDocument.ApplyTo(gpu);

        var result = await gpuService.Update(gpu, cancellationToken);
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