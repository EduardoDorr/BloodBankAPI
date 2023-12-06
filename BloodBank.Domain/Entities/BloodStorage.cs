namespace BloodBank.Domain.Entities;

public class BloodStorage : BaseEntity
{
    public string BloodType { get; set; }
    public string RhFactor { get; set; }
    public int AmountInML { get; set; }

    public BloodStorage(string bloodType, string rhFactor, int amountInML)
    {
        BloodType = bloodType;
        RhFactor = rhFactor;
        AmountInML = amountInML;

        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsActive = true;
    }

    public void AddAmount(int amount)
    {
        AmountInML += amount;
    }

    public bool WithdrawAmount(int amount)
    {
        if (AmountInML == 0 &&
            AmountInML - amount < 0)
            return false;

        AmountInML -= amount;

        return true;
    }
}