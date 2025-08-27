using FluentValidation;
using Persistence;

namespace TechnoShop.DTO;

public class ProcessorWriteDto: ProductWriteDto
{
    public required Guid SocketId { get; set; }
    public required Guid MemoryTypeId { get; set; }
    public required Guid ProcessorBrandId { get; set; }

    public decimal BaseFrequencyGHz { get; set; } 
    public decimal MaxFrequencyGHz { get; set; }  
    public int L3CacheMB { get; set; }           
    public int CoresCount { get; set; }          
    public int ThreadsCount { get; set; }        
    public int ProcessNM { get; set; }           
    public int TDP_W { get; set; }               
    public int MemoryChannels { get; set; }      
    public bool IntegratedGPU { get; set; }      
    public bool HyperThreading { get; set; }     
    public bool UnlockedMultiplier { get; set; } 
    public string PackageType { get; set; }      
    public string IncludedCooler { get; set; }   
}

/// <summary>
/// validators that use Any functions that check some
/// entity exists better to move to the services layer,
/// because it is sync call to database
/// </summary>
public class ProcessorWriteDtoValidator : AbstractValidator<ProcessorWriteDto>
{
    private readonly TechnoShopContext _context;

    public ProcessorWriteDtoValidator(TechnoShopContext context)
    {
        _context = context;

        Include(new ProductWriteDtoValidator());

        RuleFor(x => x.SocketId)
            .NotEmpty().WithMessage("Socket ID is required")
            .Must(BeValidSocketId).WithMessage("Specified socket does not exist");

        RuleFor(x => x.MemoryTypeId)
            .NotEmpty().WithMessage("Memory type ID is required")
            .Must(BeValidMemoryTypeId).WithMessage("Specified memory type does not exist");

        RuleFor(x => x.ProcessorBrandId)
            .NotEmpty().WithMessage("Processor brand ID is required")
            .Must(BeValidProcessorBrandId).WithMessage("Specified processor brand does not exist");

        RuleFor(x => x.BaseFrequencyGHz)
            .GreaterThan(0).WithMessage("Base frequency must be greater than 0 GHz")
            .LessThanOrEqualTo(10).WithMessage("Base frequency cannot exceed 10 GHz");

        RuleFor(x => x.MaxFrequencyGHz)
            .GreaterThan(0).WithMessage("Max frequency must be greater than 0 GHz")
            .LessThanOrEqualTo(10).WithMessage("Max frequency cannot exceed 10 GHz")
            .GreaterThanOrEqualTo(x => x.BaseFrequencyGHz).WithMessage("Max frequency must be greater than or equal to base frequency");

        RuleFor(x => x.L3CacheMB)
            .GreaterThanOrEqualTo(0).WithMessage("L3 Cache cannot be negative")
            .LessThanOrEqualTo(512).WithMessage("L3 Cache cannot exceed 512 MB");

        RuleFor(x => x.CoresCount)
            .GreaterThan(0).WithMessage("Cores count must be greater than 0")
            .LessThanOrEqualTo(128).WithMessage("Cores count cannot exceed 128");

        RuleFor(x => x.ThreadsCount)
            .GreaterThan(0).WithMessage("Threads count must be greater than 0")
            .LessThanOrEqualTo(256).WithMessage("Threads count cannot exceed 256")
            .GreaterThanOrEqualTo(x => x.CoresCount).WithMessage("Threads count must be greater than or equal to cores count");

        RuleFor(x => x.ProcessNM)
            .GreaterThan(0).WithMessage("Process technology must be greater than 0 nm")
            .LessThanOrEqualTo(500).WithMessage("Process technology cannot exceed 500 nm");

        RuleFor(x => x.TDP_W)
            .GreaterThan(0).WithMessage("TDP must be greater than 0 W")
            .LessThanOrEqualTo(1000).WithMessage("TDP cannot exceed 1000 W");

        RuleFor(x => x.MemoryChannels)
            .GreaterThan(0).WithMessage("Memory channels must be greater than 0")
            .LessThanOrEqualTo(16).WithMessage("Memory channels cannot exceed 16");

        RuleFor(x => x.PackageType)
            .MaximumLength(100).WithMessage("Package type cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.PackageType));

        RuleFor(x => x.IncludedCooler)
            .MaximumLength(100).WithMessage("Included cooler cannot exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.IncludedCooler));
    }
    
    private bool BeValidSocketId(Guid socketId)
    {
        return _context.Sockets.Any(s => s.Id == socketId);
    }

    private bool BeValidMemoryTypeId(Guid memoryTypeId)
    {
        return _context.MemoryTypes.Any(m => m.Id == memoryTypeId);
    }

    private bool BeValidProcessorBrandId(Guid brandId)
    {
        return _context.ProcessorBrands.Any(b => b.Id == brandId);
    }
}
