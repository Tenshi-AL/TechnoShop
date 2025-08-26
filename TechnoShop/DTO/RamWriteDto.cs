namespace TechnoShop.DTO;

public class RamWriteDto: ProductWriteDto
{
    public required Guid BrandId { get; set; }
    public required Guid MemoryTypeId { get; set; }
    
    public int CapacityGB { get; set; }
    public int ModuleCount { get; set; }
    public int FrequencyMHz { get; set; }
    public string? Timings { get; set; }
    public decimal Voltage_V { get; set; }
    public bool Heatsinks { get; set; }
    public string? XMP { get; set; }
    public string? Rank { get; set; }
    public string? ECC { get; set; }
    public string? Buffered { get; set; }
    public string? Color { get; set; }
    public string? BrandURL { get; set; }
}