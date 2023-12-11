namespace BloodBank.Domain.ValueObjects;

public enum BloodType
{
    O,
    A,
    B,
    AB
}

public enum RhFactor
{
    Positive,
    Negative
}

public sealed class BloodData : BaseValueObject
{
    public BloodType BloodType { get; }
    public RhFactor RhFactor { get; }

    protected BloodData() { }

    public BloodData(string bloodType, string rhFactor)
    {
        if (!Enum.TryParse(bloodType.Trim(), out BloodType bloodTypeResult))
            throw new ArgumentException("BloodType is invalid");

        if (!Enum.TryParse(rhFactor.Trim(), out RhFactor rhFactorResult))
            throw new ArgumentException("RhFactor is invalid");

        BloodType = bloodTypeResult;
        RhFactor = rhFactorResult;
    }

    public BloodData(BloodType bloodType, RhFactor rhFactor)
    {
        BloodType = bloodType;
        RhFactor = rhFactor;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return BloodType;
        yield return RhFactor;
    }
}