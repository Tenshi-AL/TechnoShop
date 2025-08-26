namespace Domain.Models;

public class RAMQueryParameters
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderRow { get; set; }
    public bool OrderByDesk { get; set; } = false;
    
    public List<Guid>? Brands { get; set; }
    public List<Guid>? MemoryTypes { get; set; }
    
    public int? MinCapacity { get; set; }
    public int? MaxCapacity { get; set; }
    public int? MinFrequency { get; set; }
    public int? MaxFrequency { get; set; }
    public int? MinModuleCount { get; set; }
    public int? MaxModuleCount { get; set; }
    public decimal? MinVoltage { get; set; }
    public decimal? MaxVoltage { get; set; }
    
    public bool? Heatsinks { get; set; }
    
    public string? ECC { get; set; }
    public string? Buffered { get; set; }
    public string? Rank { get; set; }
}