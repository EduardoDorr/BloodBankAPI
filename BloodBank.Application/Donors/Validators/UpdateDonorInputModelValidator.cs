using FluentValidation;

using BloodBank.Domain.Enums;
using BloodBank.Application.Donors.Models;
using BloodBank.Application.Addresses.Validators;

namespace BloodBank.Application.Donors.Validators;

public class UpdateDonorInputModelValidator : AbstractValidator<UpdateDonorInputModel>
{
    public UpdateDonorInputModelValidator()
    {
        RuleFor(r => r.Name)
            .NotNull().WithMessage("Name is required")
            .NotEmpty().WithMessage("Name must not be null or empty")
            .MinimumLength(3).WithMessage("Name must have a minimum of 3 characters")
            .MaximumLength(100).WithMessage("Name must have a maximum of 100 characters");

        RuleFor(r => r.BirthDate)
            .NotNull().WithMessage("BirthDate is required")
            .NotEmpty().WithMessage("BirthDate must not be null or empty");

        RuleFor(r => r.Weight)
           .NotNull().WithMessage("Weight is required")
           .GreaterThan(0).WithMessage("Weight is not valid");

        RuleFor(r => r.Gender)
            .NotNull().WithMessage("Gender is required")
            .NotEmpty().WithMessage("Gender must not be null or empty")
            .IsEnumName(typeof(GenderType), caseSensitive: true).WithMessage("Gender must match the specific types");

        RuleFor(r => r.BloodType)
            .NotNull().WithMessage("BloodType is required")
            .NotEmpty().WithMessage("BloodType must not be null or empty")
            .IsEnumName(typeof(BloodType), caseSensitive: true).WithMessage("BloodType must match the specific types");

        RuleFor(r => r.RhFactor)
            .NotNull().WithMessage("RhFactor is required")
            .NotEmpty().WithMessage("RhFactor must not be null or empty")
            .IsEnumName(typeof(RhFactor), caseSensitive: true).WithMessage("RhFactor must match the specific types");

        RuleFor(r => r.Email)
            .NotNull().WithMessage("Email is required")
            .NotEmpty().WithMessage("Email must not be null or empty")
            .EmailAddress().WithMessage("Email is invalid")
            .MinimumLength(5).WithMessage("Email must have a minimum of 5 characters")
            .MaximumLength(100).WithMessage("Email must have a maximum of 100 characters");

        RuleFor(r => r.Address)
            .SetValidator(new AddressModelValidator());

        RuleFor(d => d.IsActive)
            .NotNull().WithMessage("IsActive is required")
            .NotEmpty().WithMessage("IsActive must not be null or empty");
    }
}