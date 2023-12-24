using FluentValidation;

using BloodBank.Domain.Entities;
using BloodBank.Application.Donations.Models;

namespace BloodBank.Application.Donations.Validators;

public class UpdateDonationInputmodelValidator : AbstractValidator<UpdateDonationInputModel>
{
    public UpdateDonationInputmodelValidator()
    {
        RuleFor(r => r.DonationDate)
            .NotNull().WithMessage("DonationDate is required")
            .NotEmpty().WithMessage("DonationDate must not be null or empty");

        RuleFor(r => r.AmountInML)
            .NotNull().WithMessage("AmountInML is required")
            .NotEmpty().WithMessage("AmountInML must not be null or empty")
            .InclusiveBetween(Donation.MinimumAmount, Donation.MaximumAmount)
            .WithMessage($"The amount of blood must be between {Donation.MinimumAmount} and {Donation.MaximumAmount} mL");

        RuleFor(d => d.IsActive)
            .NotNull().WithMessage("IsActive is required")
            .NotEmpty().WithMessage("IsActive must not be null or empty");
    }
}