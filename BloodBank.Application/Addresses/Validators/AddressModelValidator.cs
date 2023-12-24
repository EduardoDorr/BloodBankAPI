using FluentValidation;

using BloodBank.Application.Addresses.Models;

namespace BloodBank.Application.Addresses.Validators;

public class AddressModelValidator : AbstractValidator<AddressModel>
{
    public AddressModelValidator()
    {
        RuleFor(r => r.Street)
           .NotNull().WithMessage("Street is required")
           .NotEmpty().WithMessage("Street must not be null or empty")
            .MinimumLength(5).WithMessage("Street must have a minimum of 5 characters")
            .MaximumLength(100).WithMessage("Street must have a maximum of 100 characters");

        RuleFor(r => r.City)
            .NotNull().WithMessage("City is required")
            .NotEmpty().WithMessage("City must not be null or empty")
            .MinimumLength(5).WithMessage("City must have a minimum of 5 characters")
            .MaximumLength(50).WithMessage("City must have a maximum of 50 characters");

        RuleFor(r => r.State)
            .NotNull().WithMessage("State is required")
            .NotEmpty().WithMessage("State must not be null or empty")
            .MinimumLength(5).WithMessage("State must have a minimum of 5 characters")
            .MaximumLength(25).WithMessage("State must have a maximum of 25 characters");

        RuleFor(r => r.ZipCode)
            .NotNull().WithMessage("ZipCode is required")
            .NotEmpty().WithMessage("ZipCode must not be null or empty")
            .MinimumLength(5).WithMessage("ZipCode must have a minimum of 5 characters")
            .MaximumLength(8).WithMessage("ZipCode must have a maximum of 8 characters");
    }
}