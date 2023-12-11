using BloodBank.Domain.ValueObjects;

namespace BloodBank.Domain.Entities;

public class BloodStorage : BaseEntity
{
    public BloodData BloodData { get; set; }
    public int AmountInML { get; set; }

    protected BloodStorage() { }

    public BloodStorage(string bloodType, string rhFactor, int amountInML)
    {
        BloodData = new BloodData(bloodType, rhFactor);
        AmountInML = amountInML;

        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsActive = true;
    }

    public BloodStorage(BloodData bloodData, int amountInML)
    {
        BloodData = bloodData;
        AmountInML = amountInML;

        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsActive = true;
    }

    public void AddAmount(int amountInML)
    {
        AmountInML += amountInML;
        UpdatedAt = DateTime.Now;
    }

    public bool WithdrawAmount(int amountInML)
    {
        if (AmountInML == 0 &&
            AmountInML - amountInML < 0)
            return false;

        AmountInML -= amountInML;
        UpdatedAt = DateTime.Now;

        return true;
    }
}