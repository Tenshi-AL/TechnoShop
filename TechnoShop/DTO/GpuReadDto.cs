namespace TechnoShop.DTO;

public class GpuReadDto
{
    public Guid Id { get; set; }
    
    public GpuBrandReadDto Brand { get; set; }
    public GpuManufacturerReadDto Manufacturer { get; set; }
    public MemoryTypeReadDto? MemoryType { get; set; }
    
    public string? GPUModel { get; set; }
    public int VRAM_GB { get; set; }
    public string? Interface { get; set; }
    public string? CoolingSystem { get; set; }
    public int FanCount { get; set; }
    public bool Backplate { get; set; }
    public bool ZeroFanIdle { get; set; }
    public decimal MemorySpeedGbps { get; set; }
    public int MemoryBusBit { get; set; }
    public int StreamProcessors { get; set; }
    public int HDMI_Count { get; set; }
    public string? HDMI_Version { get; set; }
    public int DisplayPort_Count { get; set; }
    public string? DisplayPort_Version { get; set; }
    public string? Dimensions_mm { get; set; }
    public decimal SlotCount { get; set; }
    public string? ExtraPower { get; set; }
    public int RecommendedPSU_W { get; set; }
    public string? MaxResolution { get; set; }
}