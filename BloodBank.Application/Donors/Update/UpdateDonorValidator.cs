using FluentValidation;
using BloodBank.Application.Donors.Update;

namespace BloodBank.API.Validators.Donors;

public class UpdateDonorValidator : AbstractValidator<UpdateDonorModel>
{
    public UpdateDonorValidator()
    {
        RuleFor(d => d.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name must not be null or empty");

        RuleFor(d => d.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Email must not be null or empty");

        RuleFor(d => d.BirthDate)
            .NotNull()
            .NotEmpty()
            .WithMessage("BirthDate must not be null or empty");

        RuleFor(d => d.Gender)
            .NotNull()
            .NotEmpty()
            .WithMessage("Gender must not be null or empty");

        RuleFor(d => d.Weight)
            .GreaterThan(0)
            .WithMessage("Weight must be a valid value");

        RuleFor(d => d.BloodType)
            .NotNull()
            .NotEmpty()
            .WithMessage("BloodType must not be null or empty");

        RuleFor(d => d.RhFactor)
            .NotNull()
            .NotEmpty()
            .WithMessage("RhFactor must not be null or empty");

        RuleFor(d => d.Address)
            .NotNull()
            .NotEmpty()
            .WithMessage("Address must not be null or empty");

        RuleFor(d => d.IsActive)
            .NotNull()
            .NotEmpty()
            .WithMessage("IsActive must not be null or empty");
    }
}