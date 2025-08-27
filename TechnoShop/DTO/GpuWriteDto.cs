using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace TechnoShop.DTO;

public class GpuWriteDto: ProductWriteDto
{
    public required Guid BrandId { get; set; }
    public required Guid ManufacturerId { get; set; }
    public required Guid MemoryTypeId { get; set; }
    
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

/// <summary>
/// validators that use Any functions that check some
/// entity exists better to move to the services layer,
/// because it is sync call to database
/// </summary>
public class GpuWriteDtoValidator : AbstractValidator<GpuWriteDto>
{
    private readonly TechnoShopContext _context;

    public GpuWriteDtoValidator(TechnoShopContext context)
    {
        _context = context;

        Include(new ProductWriteDtoValidator());

        RuleFor(x => x.BrandId)
            .NotEmpty().WithMessage("Brand ID is required")
            .Must(BeValidBrandId).WithMessage("Specified brand does not exist");

        RuleFor(x => x.ManufacturerId)
            .NotEmpty().WithMessage("Manufacturer ID is required")
            .Must(BeValidManufacturerId).WithMessage("Specified manufacturer does not exist");

        RuleFor(x => x.MemoryTypeId)
            .NotEmpty().WithMessage("Memory type ID is required")
            .Must(BeValidMemoryTypeId).WithMessage("Specified memory type does not exist");

        RuleFor(x => x.GPUModel)
            .MaximumLength(100).WithMessage("GPU model cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.GPUModel));

        RuleFor(x => x.VRAM_GB)
            .GreaterThan(0).WithMessage("VRAM must be greater than 0")
            .LessThanOrEqualTo(128).WithMessage("VRAM cannot exceed 128 GB");

        RuleFor(x => x.Interface)
            .MaximumLength(50).WithMessage("Interface cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.Interface));

        RuleFor(x => x.CoolingSystem)
            .MaximumLength(100).WithMessage("Cooling system cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.CoolingSystem));

        RuleFor(x => x.FanCount)
            .GreaterThanOrEqualTo(0).WithMessage("Fan count cannot be negative")
            .LessThanOrEqualTo(10).WithMessage("Fan count cannot exceed 10");

        RuleFor(x => x.MemorySpeedGbps)
            .GreaterThan(0).WithMessage("Memory speed must be greater than 0")
            .LessThanOrEqualTo(100).WithMessage("Memory speed cannot exceed 100 Gbps");

        RuleFor(x => x.MemoryBusBit)
            .GreaterThan(0).WithMessage("Memory bus width must be greater than 0")
            .LessThanOrEqualTo(1024).WithMessage("Memory bus width cannot exceed 1024 bits");

        RuleFor(x => x.StreamProcessors)
            .GreaterThan(0).WithMessage("Stream processors count must be greater than 0")
            .LessThanOrEqualTo(50000).WithMessage("Stream processors count cannot exceed 50000");

        RuleFor(x => x.HDMI_Count)
            .GreaterThanOrEqualTo(0).WithMessage("HDMI ports count cannot be negative")
            .LessThanOrEqualTo(10).WithMessage("HDMI ports count cannot exceed 10");

        RuleFor(x => x.HDMI_Version)
            .MaximumLength(20).WithMessage("HDMI version cannot exceed 20 characters")
            .When(x => !string.IsNullOrEmpty(x.HDMI_Version));

        RuleFor(x => x.DisplayPort_Count)
            .GreaterThanOrEqualTo(0).WithMessage("DisplayPort ports count cannot be negative")
            .LessThanOrEqualTo(10).WithMessage("DisplayPort ports count cannot exceed 10");

        RuleFor(x => x.DisplayPort_Version)
            .MaximumLength(20).WithMessage("DisplayPort version cannot exceed 20 characters")
            .When(x => !string.IsNullOrEmpty(x.DisplayPort_Version));

        RuleFor(x => x.Dimensions_mm)
            .MaximumLength(50).WithMessage("Dimensions cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.Dimensions_mm));

        RuleFor(x => x.SlotCount)
            .GreaterThan(0).WithMessage("Slot count must be greater than 0")
            .LessThanOrEqualTo(5).WithMessage("Slot count cannot exceed 5");

        RuleFor(x => x.ExtraPower)
            .MaximumLength(100).WithMessage("Extra power cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.ExtraPower));

        RuleFor(x => x.RecommendedPSU_W)
            .GreaterThanOrEqualTo(0).WithMessage("Recommended PSU wattage cannot be negative")
            .LessThanOrEqualTo(2000).WithMessage("Recommended PSU wattage cannot exceed 2000W");

        RuleFor(x => x.MaxResolution)
            .MaximumLength(50).WithMessage("Maximum resolution cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.MaxResolution));
    }

    private bool BeValidBrandId(Guid brandId)
    {
        return _context.GpuBrands.Any(b => b.Id == brandId);
    }

    private bool BeValidManufacturerId(Guid manufacturerId)
    {
        return _context.GpuManufacturers.Any(m => m.Id == manufacturerId);
    }

    private bool BeValidMemoryTypeId(Guid memoryTypeId)
    {
        return _context.MemoryTypes.Any(m => m.Id == memoryTypeId);
    }
}
