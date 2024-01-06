using BloodBank.Domain.Entities;
using BloodBank.Domain.DomainResults;

namespace BloodBank.Domain.DomainServices;

public class DonationService : IDonationService
{
    public Result<Donation> CreateDonation(Donor donor, DateTime donationDate, int amountInML)
    {
        var canDonateResult = donor.CanDonate();

        if (!canDonateResult.Success)
            return Result<Donation>.Fail(canDonateResult.Errors);

        return Result<Donation>.Ok(new Donation(donor, donationDate, amountInML));
    }
}