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
        return Ok(result);
    }

    [HttpGet(":id")]
    public async Task<IActionResult> Get(Guid id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
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