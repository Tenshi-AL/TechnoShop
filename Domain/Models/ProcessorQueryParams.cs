using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class ProcessorQueryParams
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderRow { get; set; }
    public bool OrderByDesk { get; set; } = false;
    
    // Фильтры
    public List<Guid>? Sockets { get; set; }
    public List<Guid>? ProcessorBrands { get; set; }
    public List<Guid>? MemoryTypes { get; set; }
    
    public decimal? MinFrequencyGHz { get; set; }
    public decimal? MaxFrequencyGHz { get; set; }
    public int? MinCoresCount { get; set; }
    public int? MaxCoresCount { get; set; }
    public int? MinThreadsCount { get; set; }
    public int? MaxThreadsCount { get; set; }
    public int? MinCacheMB { get; set; }
    public int? MaxCacheMB { get; set; }
    public int? MinTDP { get; set; }
    public int? MaxTDP { get; set; }
    public int? MinProcessNM { get; set; }
    public int? MaxProcessNM { get; set; }
    
    public bool? IntegratedGPU { get; set; }
    public bool? HyperThreading { get; set; }
    public bool? UnlockedMultiplier { get; set; }
}