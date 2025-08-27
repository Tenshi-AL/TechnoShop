using TechnoShop.Interfaces;

namespace TechnoShop.Models;

public class PSUQueryParameters: IQueryParameters
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderRow { get; set; }
    public bool OrderByDesk { get; set; } = false;
    
    public List<Guid>? Brands { get; set; }
    public List<Guid>? FormFactors { get; set; }
    
    public int? MinTotalPower { get; set; }
    public int? MaxTotalPower { get; set; }
    public int? MinMolexCount { get; set; }
    public int? MaxMolexCount { get; set; }
    public int? MinSATACount { get; set; }
    public int? MaxSATACount { get; set; }
    public int? MinFanSize { get; set; }
    public int? MaxFanSize { get; set; }
    
    public bool? APFC { get; set; }
    public bool? ModularCables { get; set; }
    public bool? SemiPassiveCooling { get; set; }
    
    public string? EfficiencyStandard { get; set; }
    public decimal? MinEfficiency { get; set; }
    public decimal? MaxEfficiency { get; set; }
    public string? ATXStandard { get; set; }
}