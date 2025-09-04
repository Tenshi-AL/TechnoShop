using System.Text.RegularExpressions;
using FluentValidation;

namespace TechnoShop.Models;

public class SignInRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class SignInRequestValidator : AbstractValidator<SignInRequest>
{
    public SignInRequestValidator()
    {
        RuleFor(p => p.Email)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50)
            .EmailAddress();
        
        var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s])[^\s]{8,64}$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);
        RuleFor(p => p.Password)
            .NotNull()
            .NotEmpty()
            .Matches(regex);
    }
}