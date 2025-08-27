using FluentValidation;
using Persistence;

namespace TechnoShop.DTO;

public class PsuWriteDto: ProductWriteDto
{
    public required Guid BrandId { get; set; }
    public required Guid FormFactorId { get; set; }
    
    public int TotalPower_W { get; set; }
    public int Power_3_3_5V_W { get; set; }
    public decimal Power_12V_W { get; set; }

    public decimal Current_5V_A { get; set; }
    public decimal Current_3_3V_A { get; set; }
    public decimal Current_12V1_A { get; set; }
    public decimal Current_minus12V_A { get; set; }
    public decimal Current_5Vsb_A { get; set; }

    public string? MotherboardConnector { get; set; }
    public string? CPUConnector { get; set; }
    public int MolexCount { get; set; }
    public int SATA_Count { get; set; }
    public string? GPUConnector { get; set; }

    public string? InputVoltageRange_V { get; set; }
    public bool APFC { get; set; }
    public string? EfficiencyStandard { get; set; }
    public decimal EfficiencyPercent { get; set; }
    public string? ATXStandard { get; set; }
    public bool ModularCables { get; set; }
    public bool SemiPassiveCooling { get; set; }

    public string? Dimensions_mm { get; set; }
    public int Fan_mm { get; set; }
    public string? Notes { get; set; }
    public string? BrandURL { get; set; }
}

/// <summary>
/// validators that use Any functions that check some
/// entity exists better to move to the services layer,
/// because it is sync call to database
/// </summary>
public class PsuWriteDtoValidator : AbstractValidator<PsuWriteDto>
{
    private readonly TechnoShopContext _context;

    public PsuWriteDtoValidator(TechnoShopContext context)
    {
        _context = context;

        Include(new ProductWriteDtoValidator());

        RuleFor(x => x.BrandId)
            .NotEmpty().WithMessage("Brand ID is required")
            .Must(BeValidBrandId).WithMessage("Specified brand does not exist");

        RuleFor(x => x.FormFactorId)
            .NotEmpty().WithMessage("Form factor ID is required")
            .Must(BeValidFormFactorId).WithMessage("Specified form factor does not exist");

        RuleFor(x => x.TotalPower_W)
            .GreaterThan(0).WithMessage("Total power must be greater than 0 W")
            .LessThanOrEqualTo(3000).WithMessage("Total power cannot exceed 3000 W");

        RuleFor(x => x.Power_3_3_5V_W)
            .GreaterThanOrEqualTo(0).WithMessage("3.3V + 5V power cannot be negative")
            .LessThanOrEqualTo(500).WithMessage("3.3V + 5V power cannot exceed 500 W");

        RuleFor(x => x.Power_12V_W)
            .GreaterThanOrEqualTo(0).WithMessage("12V power cannot be negative")
            .LessThanOrEqualTo(3000).WithMessage("12V power cannot exceed 3000 W");

        RuleFor(x => x.Current_5V_A)
            .GreaterThanOrEqualTo(0).WithMessage("5V current cannot be negative")
            .LessThanOrEqualTo(100).WithMessage("5V current cannot exceed 100 A");

        RuleFor(x => x.Current_3_3V_A)
            .GreaterThanOrEqualTo(0).WithMessage("3.3V current cannot be negative")
            .LessThanOrEqualTo(100).WithMessage("3.3V current cannot exceed 100 A");

        RuleFor(x => x.Current_12V1_A)
            .GreaterThanOrEqualTo(0).WithMessage("12V current cannot be negative")
            .LessThanOrEqualTo(200).WithMessage("12V current cannot exceed 200 A");

        RuleFor(x => x.Current_minus12V_A)
            .GreaterThanOrEqualTo(0).WithMessage("-12V current cannot be negative")
            .LessThanOrEqualTo(10).WithMessage("-12V current cannot exceed 10 A");

        RuleFor(x => x.Current_5Vsb_A)
            .GreaterThanOrEqualTo(0).WithMessage("5Vsb current cannot be negative")
            .LessThanOrEqualTo(10).WithMessage("5Vsb current cannot exceed 10 A");

        RuleFor(x => x.MotherboardConnector)
            .MaximumLength(50).WithMessage("Motherboard connector cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.MotherboardConnector));

        RuleFor(x => x.CPUConnector)
            .MaximumLength(50).WithMessage("CPU connector cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.CPUConnector));

        RuleFor(x => x.MolexCount)
            .GreaterThanOrEqualTo(0).WithMessage("Molex count cannot be negative")
            .LessThanOrEqualTo(20).WithMessage("Molex count cannot exceed 20");

        RuleFor(x => x.SATA_Count)
            .GreaterThanOrEqualTo(0).WithMessage("SATA count cannot be negative")
            .LessThanOrEqualTo(20).WithMessage("SATA count cannot exceed 20");

        RuleFor(x => x.GPUConnector)
            .MaximumLength(50).WithMessage("GPU connector cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.GPUConnector));

        RuleFor(x => x.InputVoltageRange_V)
            .MaximumLength(50).WithMessage("Input voltage range cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.InputVoltageRange_V));

        RuleFor(x => x.EfficiencyStandard)
            .MaximumLength(50).WithMessage("Efficiency standard cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.EfficiencyStandard));

        RuleFor(x => x.EfficiencyPercent)
            .GreaterThan(0).WithMessage("Efficiency percent must be greater than 0%")
            .LessThanOrEqualTo(100).WithMessage("Efficiency percent cannot exceed 100%");

        RuleFor(x => x.ATXStandard)
            .MaximumLength(50).WithMessage("ATX standard cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.ATXStandard));

        RuleFor(x => x.Dimensions_mm)
            .MaximumLength(50).WithMessage("Dimensions cannot exceed 50 characters")
            .When(x => !string.IsNullOrEmpty(x.Dimensions_mm));

        RuleFor(x => x.Fan_mm)
            .GreaterThanOrEqualTo(0).WithMessage("Fan size cannot be negative")
            .LessThanOrEqualTo(300).WithMessage("Fan size cannot exceed 300 mm");

        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage("Notes cannot exceed 500 characters")
            .When(x => !string.IsNullOrEmpty(x.Notes));

        RuleFor(x => x.BrandURL)
            .MaximumLength(200).WithMessage("Brand URL cannot exceed 200 characters")
            .When(x => !string.IsNullOrEmpty(x.BrandURL));
    }

    private bool BeValidBrandId(Guid brandId)
    {
        return _context.PsuBrands.Any(b => b.Id == brandId);
    }

    private bool BeValidFormFactorId(Guid formFactorId)
    {
        return _context.PsuFormFactors.Any(f => f.Id == formFactorId);
    }
}
