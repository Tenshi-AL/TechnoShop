using FluentValidation;
using Persistence;

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

/// <summary>
/// validators that use Any functions that check some
/// entity exists better to move to the services layer,
/// because it is sync call to database
/// </summary>
public class RamWriteDtoValidator : AbstractValidator<RamWriteDto>
{
    private readonly TechnoShopContext _context;

    public RamWriteDtoValidator(TechnoShopContext context)
    {
        _context = context;

        Include(new ProductWriteDtoValidator());

        RuleFor(x => x.BrandId)
            .NotEmpty().WithMessage("Brand ID is required")
            .Must(BeValidBrandId).WithMessage("Specified brand does not exist");

        RuleFor(x => x.MemoryTypeId)
            .NotEmpty().WithMessage("Memory type ID is required")
            .Must(BeValidMemoryTypeId).WithMessage("Specified memory type does not exist");

        RuleFor(x => x.CapacityGB)
            .GreaterThan(0).WithMessage("Capacity must be greater than 0 GB")
            .LessThanOrEqualTo(1024).WithMessage("Capacity cannot exceed 1024 GB");

        RuleFor(x => x.ModuleCount)
            .GreaterThan(0).WithMessage("Module count must be greater than 0")
            .LessThanOrEqualTo(16).WithMessage("Module count cannot exceed 16");

        RuleFor(x => x.FrequencyMHz)
            .GreaterThan(0).WithMessage("Frequency must be greater than 0 MHz")
            .LessThanOrEqualTo(12000).WithMessage("Frequency cannot exceed 12000 MHz");

        RuleFor(x => x.Timings)
            .MaximumLength(50).WithMessage("Timings cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.Timings));

        RuleFor(x => x.Voltage_V)
            .GreaterThan(0).WithMessage("Voltage must be greater than 0 V")
            .LessThanOrEqualTo(2).WithMessage("Voltage cannot exceed 2 V");

        RuleFor(x => x.XMP)
            .MaximumLength(50).WithMessage("XMP info cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.XMP));

        RuleFor(x => x.Rank)
            .MaximumLength(50).WithMessage("Rank info cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.Rank));

        RuleFor(x => x.ECC)
            .MaximumLength(50).WithMessage("ECC info cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.ECC));

        RuleFor(x => x.Buffered)
            .MaximumLength(50).WithMessage("Buffered info cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.Buffered));

        RuleFor(x => x.Color)
            .MaximumLength(50).WithMessage("Color cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.Color));

        RuleFor(x => x.BrandURL)
            .MaximumLength(200).WithMessage("Brand URL cannot exceed 200 characters")
            .When(x => !string.IsNullOrEmpty(x.BrandURL));
    }

    private bool BeValidBrandId(Guid brandId)
    {
        return _context.RamBrands.Any(b => b.Id == brandId);
    }

    private bool BeValidMemoryTypeId(Guid memoryTypeId)
    {
        return _context.MemoryTypes.Any(m => m.Id == memoryTypeId);
    }
}
