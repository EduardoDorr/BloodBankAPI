using BloodBank.Domain.ValueObjects;

namespace BloodBank.Test.Utils;

internal static class AddressUtils
{
    public static Address CreateAValidAddress()
    {
        return new Address("Rua A", "Cidade B", "Estado C", "11111111");
    }
}