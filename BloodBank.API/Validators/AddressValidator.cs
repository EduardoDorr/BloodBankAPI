using FluentValidation;

using BloodBank.Domain.ValueObjects;

namespace BloodBank.API.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.Street)
            .NotNull()
            .NotEmpty()
            .WithMessage("Street must not be null or empty");

        RuleFor(a => a.City)
            .NotNull()
            .NotEmpty()
            .WithMessage("City must not be null or empty");

        RuleFor(a => a.State)
            .NotNull()
            .NotEmpty()
            .WithMessage("State must not be null or empty");

        RuleFor(a => a.ZipCode)
            .NotNull()
            .NotEmpty()
            .WithMessage("ZipCode must not be null or empty");
    }
}
