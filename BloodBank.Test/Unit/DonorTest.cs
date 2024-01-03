using BloodBank.Test.Utils;

namespace BloodBank.Test.Unit;

public class DonorTest
{
    [Fact]
    public void DonorIsOfLegalAge_CanDonate()
    {
        // Arrange
        var address = AddressUtils.CreateAValidAddress();

        var donor = DonorUtils.CreateDonor(new DateTime(2005, 11, 8), 70.00, address);

        donor.Donations.Add(DonationUtils.CreateDonation(donor, DateTime.Today.AddDays(-100), 450));

        // Act
        var donation = donor.CanDonate();

        // Assert
        Assert.NotNull(donation);
    }

    [Fact]
    public void DonorIsMinor_CanNotDonate()
    {
        // Arrange
        var address = AddressUtils.CreateAValidAddress();

        var donor = DonorUtils.CreateDonor(new DateTime(2006, 11, 8), 70.00, address);

        donor.Donations.Add(DonationUtils.CreateDonation(donor, DateTime.Today.AddDays(-100), 450));

        // Act+Assert
        Assert.Throws<Exception>(() => donor.CanDonate());
    }

    [Fact]
    public void DonorRecentlyDonated_CanNotDonate()
    {
        // Arrange
        var address = AddressUtils.CreateAValidAddress();

        var donor = DonorUtils.CreateDonor(new DateTime(2006, 11, 8), 70.00, address);

        donor.Donations.Add(DonationUtils.CreateDonation(donor, DateTime.Today, 450));

        // Act+Assert
        Assert.Throws<Exception>(() => donor.CanDonate());
    }

    [Fact]
    public void DonorHasNotMinimumWeight_CanNotCreate()
    {
        // Arrange
        var address = AddressUtils.CreateAValidAddress();

        // Act+Assert
        Assert.Throws<ArgumentException>(() => DonorUtils.CreateDonor(new DateTime(2005, 11, 8), 49.00, address));
    }
}