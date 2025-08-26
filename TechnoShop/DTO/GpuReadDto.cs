namespace TechnoShop.DTO;

public class GpuReadDto: ProductReadDto
{
    public GpuBrandReadDto Brand { get; init; }
    public GpuManufacturerReadDto Manufacturer { get; init; }
    public MemoryTypeReadDto? MemoryType { get; init; }
    
    public string? GPUModel { get; init; }
    public int VRAM_GB { get; init; }
    public string? Interface { get; init; }
    public string? CoolingSystem { get; init; }
    public int FanCount { get; init; }
    public bool Backplate { get; init; }
    public bool ZeroFanIdle { get; init; }
    public decimal MemorySpeedGbps { get; init; }
    public int MemoryBusBit { get; init; }
    public int StreamProcessors { get; init; }
    public int HDMI_Count { get; init; }
    public string? HDMI_Version { get; init; }
    public int DisplayPort_Count { get; init; }
    public string? DisplayPort_Version { get; init; }
    public string? Dimensions_mm { get; init; }
    public decimal SlotCount { get; init; }
    public string? ExtraPower { get; init; }
    public int RecommendedPSU_W { get; init; }
    public string? MaxResolution { get; init; }
}