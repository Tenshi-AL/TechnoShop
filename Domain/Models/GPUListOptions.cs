using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class GpuQueryParameters
{
    [Range(0, int.MaxValue)]
    public int? MinVramGb { get; set; }
    
    [Range(0, int.MaxValue)]
    public int? MaxVramGb { get; set; }
    
    public ICollection<Guid>? MemoryTypes { get; set; }
    public ICollection<Guid>? Manufacturers { get; set; }
    public ICollection<Guid>? Brands { get; set; }

    public string? OrderRow { get; set; } = null;
    public bool OrderByDesk { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Page { get; set; } = 0;
    
    [Range(0, int.MaxValue)]
    public int PageSize { get; set; } = 5;
}