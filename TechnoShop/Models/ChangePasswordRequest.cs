using System.Text.RegularExpressions;
using FluentValidation;

namespace TechnoShop.Models;

public class ChangePasswordRequest
{
    public required string Email { get; set; }
    public required string CurrentPassword { get; set; }
    public required string NewPassword { get; set; }
}

public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {
        RuleFor(p => p.Email)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50)
            .EmailAddress();
        
        var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s])[^\s]{8,64}$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);
        
        RuleFor(p => p.CurrentPassword)
            .NotNull()
            .NotEmpty()
            .Matches(regex);
        
        RuleFor(p => p.NewPassword)
            .NotNull()
            .NotEmpty()
            .NotEqual(p=>p.CurrentPassword)
            .Matches(regex);
    }
}