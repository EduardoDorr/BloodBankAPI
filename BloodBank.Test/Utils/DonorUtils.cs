using BloodBank.Domain.Entities;
using BloodBank.Domain.ValueObjects;

namespace BloodBank.Test.Utils;

internal static class DonorUtils
{
    public static Donor CreateDonor(DateTime birthDate, double weight, Address address)
    {
        return new Donor("Teste",
                         "teste@mail.com",
                         birthDate,
                         "Male", weight, "O",
                         "Positive", address);
    }    
}