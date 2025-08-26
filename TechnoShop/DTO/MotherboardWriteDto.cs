namespace TechnoShop.DTO;

public class MotherboardWriteDto: ProductWriteDto
{
    public required Guid ChipsetId { get; set; }
    public required Guid MotherboardBrandId { get; set; }
    public Guid SocketId { get; set; }
    
    public string? ChipsetCooling { get; set; }
    public string? VRMCooling { get; set; }
        
    public string? DIMMSlots { get; set; }
    public string? PCIe_x16 { get; set; }
    public int PCIe_x1 { get; set; }
        
    public string? MotherboardPower { get; set; }
    public string? CPU_Power { get; set; }
        
    public int FanHeaders { get; set; }
        
    public int M2Slots { get; set; }
    public string? M2Type { get; set; }
    public int SATA3 { get; set; }
        
    public string? AudioCodec { get; set; }
    public string? Ethernet { get; set; }
    public int RearLAN { get; set; }
    public int RearAudio { get; set; }
        
    public string? VideoOutputs { get; set; }
        
    public int RearUSB3_2Gen2x2TypeC { get; set; }
    public int RearUSB3_2Gen2TypeA { get; set; }
    public int RearUSB3_2Gen1TypeA { get; set; }
    public int RearUSB2_0 { get; set; }
    public string? OnboardUSB3_2Gen2 { get; set; }
    public string? OnboardUSB3_2Gen1 { get; set; }
    public string? OnboardUSB2_0 { get; set; }
        
    public string? FormFactor { get; set; }
    public string? RAIDSupport { get; set; }
        
    public string? WiFiAdapter { get; set; }
    public string? BluetoothAdapter { get; set; }
    public bool ReinforcedPCIESlot { get; set; }
    public bool M2Cooling { get; set; }
    public bool BIOSFlashBack { get; set; }
    public string? Misc { get; set; }
    public string? BrandURL { get; set; }
}