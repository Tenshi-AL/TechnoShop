using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TechnoShop.Controllers;

[ApiController]
[Route("[controller]")]
public class GpuController(IGpuService gpuService): ControllerBase
{
    [HttpGet("List")]
    public IActionResult List()
    {
        return Ok(gpuService.List());
    }
    
}