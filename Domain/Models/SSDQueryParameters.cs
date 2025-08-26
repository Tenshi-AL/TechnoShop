namespace Domain.Models;

public class SSDQueryParameters
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderRow { get; set; }
    public bool OrderByDesk { get; set; } = false;

    public List<Guid>? Brands { get; set; }
    public List<Guid>? FormFactors { get; set; }
    
    public int? MinCapacity { get; set; }
    public int? MaxCapacity { get; set; }
    public int? MinReadSpeed { get; set; }
    public int? MaxReadSpeed { get; set; }
    public int? MinWriteSpeed { get; set; }
    public int? MaxWriteSpeed { get; set; }
    public int? MinTBW { get; set; }
    public int? MaxTBW { get; set; }
    public decimal? MinMTBF { get; set; }
    public decimal? MaxMTBF { get; set; }
    public int? MinWeight { get; set; }
    public int? MaxWeight { get; set; }
    
    public bool? TRIMSupport { get; set; }
    
    public string? Interface { get; set; }
    public string? NANDType { get; set; }
    public string? Series { get; set; }
}