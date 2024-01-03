using BloodBank.Domain.Entities;

namespace BloodBank.Test.Utils;

internal static class DonationUtils
{
    public static Donation CreateDonation(Donor donor, DateTime donationDate, int amountInML)
    {
        var donation = new Donation(donor, donationDate, amountInML);

        return donation;
    }
}