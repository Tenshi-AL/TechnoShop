using FluentValidation;

namespace TechnoShop.DTO;

public class ProductWriteDto
{
    //public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required bool InStock { get; init; }
}

/// <summary>
/// validators that use Any functions that check some
/// entity exists better to move to the services layer,
/// because it is sync call to database
/// </summary>
public class ProductWriteDtoValidator : AbstractValidator<ProductWriteDto>
{
    public ProductWriteDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required")
            .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}