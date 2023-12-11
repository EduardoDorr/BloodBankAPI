using System.Text.RegularExpressions;

namespace BloodBank.Domain.ValueObjects;

public sealed class Email : BaseValueObject
{
    public string Address { get; } = string.Empty;

    private const string _pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    protected Email()
    {
    }

    public Email(string address)
    {
        if (string.IsNullOrEmpty(address) || address.Length < 5)
            throw new ArgumentException("Email is too short");

        if (!Regex.IsMatch(address, _pattern))
            throw new ArgumentException("Email format is invalid");

        Address = address.ToLower().Trim();
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Address;
    }

    public override string ToString()
    {
        return Address;
    }
}