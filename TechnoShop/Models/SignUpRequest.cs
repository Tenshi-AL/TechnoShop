using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FluentValidation;

namespace TechnoShop.Models;

public class SignUpRequest
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}

public class RegistrationRequestValidator: AbstractValidator<SignUpRequest>
{
    
    public RegistrationRequestValidator()
    {
        RuleFor(p => p.Email)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50)
            .EmailAddress();

        RuleFor(p => p.FirstName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(p => p.LastName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);
        
        var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s])[^\s]{8,64}$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);
        RuleFor(p => p.Password)
            .NotNull()
            .NotEmpty()
            .Matches(regex);
    }
}