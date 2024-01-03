using BloodBank.Domain.Entities;

namespace BloodBank.Domain.DomainServices;

public interface IDonationService
{
    Donation CreateDonation(Donor donor, DateTime donationDate, int amountInML);
}