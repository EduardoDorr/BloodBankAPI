using BloodBank.Domain.Entities;

namespace BloodBank.Domain.DomainServices;

public class DonationService : IDonationService
{
    public Donation CreateDonation(Donor donor, DateTime donationDate, int amountInML)
    {
        if (!donor.CanDonate())
            throw new Exception("Donor can't donate");

        return new Donation(donor, donationDate, amountInML);
    }
}