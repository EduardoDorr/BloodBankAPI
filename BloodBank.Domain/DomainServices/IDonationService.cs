using BloodBank.Domain.Entities;
using BloodBank.Domain.DomainResults;

namespace BloodBank.Domain.DomainServices;

public interface IDonationService
{
    Result<Donation> CreateDonation(Donor donor, DateTime donationDate, int amountInML);
}