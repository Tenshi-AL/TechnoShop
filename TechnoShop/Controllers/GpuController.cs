using System.Net;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using TechnoShop.DTO;

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
        var list = await gpuService.List(parameters, cancellationToken);
        var result = mapper.Map<List<GpuReadDto>>(list);
        return Ok(new
        {
            result,
            parameters.PageSize,
            parameters.Page,
        });
    }

    /// <summary>
    /// Return gpu instance
    /// </summary>
    /// <param name="id">GPU id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>GPU instance</returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet(":id")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var gpu = await gpuService.Get(id, cancellationToken);
        if (gpu is null) return NotFound();
        var result = mapper.Map<GpuReadDto>(gpu);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
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