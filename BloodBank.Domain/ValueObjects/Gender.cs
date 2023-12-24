using BloodBank.Domain.Enums;

namespace BloodBank.Domain.ValueObjects;

public sealed class Gender : BaseValueObject
{
    public GenderType Type { get; }

    protected Gender() { }

    public Gender(string gender)
    {
        if (!Enum.TryParse(gender.Trim(), out GenderType genderResult))
            throw new ArgumentException("Gender is invalid");

        Type = genderResult;
    }

    public Gender(GenderType gender) => Type = gender;

    public bool IsMale() => Type == GenderType.Male;
    public bool IsFemale() => Type == GenderType.Female;

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Type;
    }

    public override string ToString()
    {
        return Type.ToString();
    }
}
