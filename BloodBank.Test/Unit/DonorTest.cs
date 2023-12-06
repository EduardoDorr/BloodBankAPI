using BloodBank.Domain.Entities;

namespace BloodBank.Test.Unit;

public class DonorTest
{
    [Fact]
    public void DonorIsOfLegalAge_CanDonate()
    {
        // Arrange
        var donor = new Donor("Teste",
                              "teste@mail.com",
                              new DateTime(2005, 11, 8),
                              "Male", 70.00, "O",
                              "Positive", 1);

        // Act
        var canDonate = donor.CanDonate();

        // Assert
        Assert.True(canDonate);
    }

    [Fact]
    public void DonorIsMinor_CanNotDonate()
    {
        // Arrange
        var donor = new Donor("Teste",
                              "teste@mail.com",
                              new DateTime(2006, 11, 8),
                              "Male", 70.00, "O",
                              "Positive", 1);

        // Act
        var canDonate = donor.CanDonate();

        // Assert
        Assert.False(canDonate);
    }
}