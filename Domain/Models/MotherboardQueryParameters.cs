namespace Domain.Models;

public class MotherboardQueryParameters
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderRow { get; set; }
    public bool OrderByDesk { get; set; } = false;
    
    public List<Guid>? Chipsets { get; set; }
    public List<Guid>? MotherboardBrands { get; set; }
    public List<Guid>? Sockets { get; set; }
    
    public int? MinM2Slots { get; set; }
    public int? MaxM2Slots { get; set; }
    public int? MinSATA3 { get; set; }
    public int? MaxSATA3 { get; set; }
    public int? MinFanHeaders { get; set; }
    public int? MaxFanHeaders { get; set; }
    public int? MinPCIe_x1 { get; set; }
    public int? MaxPCIe_x1 { get; set; }
    
    public bool? ReinforcedPCIESlot { get; set; }
    public bool? M2Cooling { get; set; }
    public bool? BIOSFlashBack { get; set; }
    
    public string? FormFactor { get; set; }
    public string? M2Type { get; set; }
}