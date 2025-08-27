using FluentValidation;
using Persistence;

namespace TechnoShop.DTO;

public class SsdWriteDto: ProductWriteDto
{
    public required Guid BrandId { get; set; }
    public required Guid FormFactorId { get; set; }
    
    public string? Series { get; set; }
    public int CapacityGB { get; set; }
    public string? Interface { get; set; }
    public string? NANDType { get; set; }
    public bool TRIMSupport { get; set; }
    public string? Dimensions_mm { get; set; }
    public int Weight_g { get; set; }
    public int MaxReadMBs { get; set; }
    public int MaxWriteMBs { get; set; }
    public int TBW { get; set; }
    public decimal MTBF_MillionHours { get; set; }
    public string? BrandURL { get; set; }
}

/// <summary>
/// validators that use Any functions that check some
/// entity exists better to move to the services layer,
/// because it is sync call to database
/// </summary>
public class SsdWriteDtoValidator : AbstractValidator<SsdWriteDto>
{
    private readonly TechnoShopContext _context;

    public SsdWriteDtoValidator(TechnoShopContext context)
    {
        _context = context;

        Include(new ProductWriteDtoValidator());

        RuleFor(x => x.BrandId)
            .NotEmpty().WithMessage("Brand ID is required")
            .Must(BeValidBrandId).WithMessage("Specified brand does not exist");

        RuleFor(x => x.FormFactorId)
            .NotEmpty().WithMessage("Form factor ID is required")
            .Must(BeValidFormFactorId).WithMessage("Specified form factor does not exist");

        RuleFor(x => x.Series)
            .MaximumLength(100).WithMessage("Series cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.Series));

        RuleFor(x => x.CapacityGB)
            .GreaterThan(0).WithMessage("Capacity must be greater than 0 GB")
            .LessThanOrEqualTo(32768).WithMessage("Capacity cannot exceed 32 TB");

        RuleFor(x => x.Interface)
            .MaximumLength(50).WithMessage("Interface cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.Interface));

        RuleFor(x => x.NANDType)
            .MaximumLength(50).WithMessage("NAND type cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.NANDType));

        RuleFor(x => x.Dimensions_mm)
            .MaximumLength(50).WithMessage("Dimensions cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.Dimensions_mm));

        RuleFor(x => x.Weight_g)
            .GreaterThanOrEqualTo(0).WithMessage("Weight cannot be negative")
            .LessThanOrEqualTo(2000).WithMessage("Weight cannot exceed 2000 g");

        RuleFor(x => x.MaxReadMBs)
            .GreaterThan(0).WithMessage("Max read speed must be greater than 0 MB/s")
            .LessThanOrEqualTo(15000).WithMessage("Max read speed cannot exceed 15000 MB/s");

        RuleFor(x => x.MaxWriteMBs)
            .GreaterThan(0).WithMessage("Max write speed must be greater than 0 MB/s")
            .LessThanOrEqualTo(15000).WithMessage("Max write speed cannot exceed 15000 MB/s");

        RuleFor(x => x.TBW)
            .GreaterThanOrEqualTo(0).WithMessage("TBW cannot be negative")
            .LessThanOrEqualTo(10000000).WithMessage("TBW cannot exceed 10,000,000 TBW");

        RuleFor(x => x.MTBF_MillionHours)
            .GreaterThan(0).WithMessage("MTBF must be greater than 0")
            .LessThanOrEqualTo(10).WithMessage("MTBF cannot exceed 10 million hours");

        RuleFor(x => x.BrandURL)
            .MaximumLength(200).WithMessage("Brand URL cannot exceed 200 characters")
            .When(x => !string.IsNullOrEmpty(x.BrandURL));
    }

    private bool BeValidBrandId(Guid brandId)
    {
        return _context.SsdBrands.Any(b => b.Id == brandId);
    }

    private bool BeValidFormFactorId(Guid formFactorId)
    {
        return _context.SsdFormFactors.Any(f => f.Id == formFactorId);
    }
}
