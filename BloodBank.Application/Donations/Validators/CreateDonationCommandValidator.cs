using FluentValidation;

using BloodBank.Domain.Entities;
using BloodBank.Application.Donations.Commands;

namespace BloodBank.Application.Donations.Validators;

public class CreateDonationCommandValidator : AbstractValidator<CreateDonationCommand>
{
    public CreateDonationCommandValidator()
    {
        RuleFor(r => r.DonorId)
           .NotNull().WithMessage("DonorId is required")
           .GreaterThan(0).WithMessage("DonorId is not valid");

        RuleFor(r => r.DonationDate)
            .NotNull().WithMessage("DonationDate is required")
            .NotEmpty().WithMessage("DonationDate must not be null or empty");

        RuleFor(r => r.AmountInML)
            .NotNull().WithMessage("AmountInML is required")
            .NotEmpty().WithMessage("AmountInML must not be null or empty")
            .InclusiveBetween(Donation.MinimumAmount, Donation.MaximumAmount)
            .WithMessage($"The amount of blood must be between {Donation.MinimumAmount} and {Donation.MaximumAmount} mL");
    }
}