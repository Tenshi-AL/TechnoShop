using FluentValidation;
using Persistence;

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

/// <summary>
/// validators that use Any functions that check some
/// entity exists better to move to the services layer,
/// because it is sync call to database
/// </summary>
public class MotherboardWriteDtoValidator : AbstractValidator<MotherboardWriteDto>
{
    private readonly TechnoShopContext _context;

    public MotherboardWriteDtoValidator(TechnoShopContext context)
    {
        _context = context;

        Include(new ProductWriteDtoValidator());

        RuleFor(x => x.ChipsetId)
            .NotEmpty().WithMessage("Chipset ID is required")
            .Must(BeValidChipsetId).WithMessage("Specified chipset does not exist");

        RuleFor(x => x.MotherboardBrandId)
            .NotEmpty().WithMessage("Motherboard brand ID is required")
            .Must(BeValidMotherboardBrandId).WithMessage("Specified brand does not exist");

        RuleFor(x => x.SocketId)
            .NotEmpty().WithMessage("Socket ID is required")
            .Must(BeValidSocketId).WithMessage("Specified socket does not exist");

        RuleFor(x => x.ChipsetCooling)
            .MaximumLength(100).WithMessage("Chipset cooling cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.ChipsetCooling));

        RuleFor(x => x.VRMCooling)
            .MaximumLength(100).WithMessage("VRM cooling cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.VRMCooling));

        RuleFor(x => x.DIMMSlots)
            .MaximumLength(50).WithMessage("DIMM slots info cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.DIMMSlots));

        RuleFor(x => x.PCIe_x16)
            .MaximumLength(50).WithMessage("PCIe x16 info cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.PCIe_x16));

        RuleFor(x => x.PCIe_x1)
            .GreaterThanOrEqualTo(0).WithMessage("PCIe x1 slot count cannot be negative")
            .LessThanOrEqualTo(10).WithMessage("PCIe x1 slot count cannot exceed 10");

        RuleFor(x => x.MotherboardPower)
            .MaximumLength(50).WithMessage("Motherboard power cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.MotherboardPower));

        RuleFor(x => x.CPU_Power)
            .MaximumLength(50).WithMessage("CPU power cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.CPU_Power));

        RuleFor(x => x.FanHeaders)
            .GreaterThanOrEqualTo(0).WithMessage("Fan headers count cannot be negative")
            .LessThanOrEqualTo(20).WithMessage("Fan headers count cannot exceed 20");

        RuleFor(x => x.M2Slots)
            .GreaterThanOrEqualTo(0).WithMessage("M.2 slots count cannot be negative")
            .LessThanOrEqualTo(10).WithMessage("M.2 slots count cannot exceed 10");

        RuleFor(x => x.M2Type)
            .MaximumLength(50).WithMessage("M.2 type cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.M2Type));

        RuleFor(x => x.SATA3)
            .GreaterThanOrEqualTo(0).WithMessage("SATA3 ports count cannot be negative")
            .LessThanOrEqualTo(20).WithMessage("SATA3 ports count cannot exceed 20");

        RuleFor(x => x.AudioCodec)
            .MaximumLength(100).WithMessage("Audio codec cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.AudioCodec));

        RuleFor(x => x.Ethernet)
            .MaximumLength(100).WithMessage("Ethernet cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.Ethernet));

        RuleFor(x => x.RearLAN)
            .GreaterThanOrEqualTo(0).WithMessage("Rear LAN ports count cannot be negative")
            .LessThanOrEqualTo(5).WithMessage("Rear LAN ports count cannot exceed 5");

        RuleFor(x => x.RearAudio)
            .GreaterThanOrEqualTo(0).WithMessage("Rear audio ports count cannot be negative")
            .LessThanOrEqualTo(10).WithMessage("Rear audio ports count cannot exceed 10");

        RuleFor(x => x.VideoOutputs)
            .MaximumLength(100).WithMessage("Video outputs cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.VideoOutputs));

        RuleFor(x => x.RearUSB3_2Gen2x2TypeC)
            .GreaterThanOrEqualTo(0).WithMessage("Rear USB 3.2 Gen2x2 Type-C count cannot be negative")
            .LessThanOrEqualTo(5).WithMessage("Rear USB 3.2 Gen2x2 Type-C count cannot exceed 5");

        RuleFor(x => x.RearUSB3_2Gen2TypeA)
            .GreaterThanOrEqualTo(0).WithMessage("Rear USB 3.2 Gen2 Type-A count cannot be negative")
            .LessThanOrEqualTo(10).WithMessage("Rear USB 3.2 Gen2 Type-A count cannot exceed 10");

        RuleFor(x => x.RearUSB3_2Gen1TypeA)
            .GreaterThanOrEqualTo(0).WithMessage("Rear USB 3.2 Gen1 Type-A count cannot be negative")
            .LessThanOrEqualTo(10).WithMessage("Rear USB 3.2 Gen1 Type-A count cannot exceed 10");

        RuleFor(x => x.RearUSB2_0)
            .GreaterThanOrEqualTo(0).WithMessage("Rear USB 2.0 count cannot be negative")
            .LessThanOrEqualTo(20).WithMessage("Rear USB 2.0 count cannot exceed 20");

        RuleFor(x => x.OnboardUSB3_2Gen2)
            .MaximumLength(50).WithMessage("Onboard USB 3.2 Gen2 info cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.OnboardUSB3_2Gen2));

        RuleFor(x => x.OnboardUSB3_2Gen1)
            .MaximumLength(50).WithMessage("Onboard USB 3.2 Gen1 info cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.OnboardUSB3_2Gen1));

        RuleFor(x => x.OnboardUSB2_0)
            .MaximumLength(50).WithMessage("Onboard USB 2.0 info cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.OnboardUSB2_0));

        RuleFor(x => x.FormFactor)
            .MaximumLength(50).WithMessage("Form factor cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.FormFactor));

        RuleFor(x => x.RAIDSupport)
            .MaximumLength(50).WithMessage("RAID support cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.RAIDSupport));

        RuleFor(x => x.WiFiAdapter)
            .MaximumLength(100).WithMessage("WiFi adapter cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.WiFiAdapter));

        RuleFor(x => x.BluetoothAdapter)
            .MaximumLength(100).WithMessage("Bluetooth adapter cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.BluetoothAdapter));

        RuleFor(x => x.Misc)
            .MaximumLength(200).WithMessage("Misc field cannot exceed 200 characters")
            .When(x => !string.IsNullOrEmpty(x.Misc));

        RuleFor(x => x.BrandURL)
            .MaximumLength(200).WithMessage("Brand URL cannot exceed 200 characters")
            .When(x => !string.IsNullOrEmpty(x.BrandURL));
    }

    private bool BeValidChipsetId(Guid chipsetId)
    {
        return _context.Chipsets.Any(c => c.Id == chipsetId);
    }

    private bool BeValidMotherboardBrandId(Guid brandId)
    {
        return _context.MotherboardBrands.Any(b => b.Id == brandId);
    }

    private bool BeValidSocketId(Guid socketId)
    {
        return _context.Sockets.Any(s => s.Id == socketId);
    }
}
