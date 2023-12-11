namespace BloodBank.Domain.ValueObjects;

public sealed class Address : BaseValueObject
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string ZipCode { get; }

    protected Address() { }

    public Address(string street, string city, string state, string zipCode)
    {
        if (string.IsNullOrEmpty(street) || street.Length < 5)
            throw new ArgumentException("Street is too short");

        if (string.IsNullOrEmpty(city) || city.Length < 5)
            throw new ArgumentException("City is too short");

        if (string.IsNullOrEmpty(state) || state.Length < 5)
            throw new ArgumentException("State is too short");

        if (string.IsNullOrEmpty(zipCode) || zipCode.Length < 5)
            throw new ArgumentException("ZipCode is too short");

        Street = street.Trim();
        City = city.Trim();
        State = state.Trim();
        ZipCode = zipCode.Trim();
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return ZipCode;
    }
}