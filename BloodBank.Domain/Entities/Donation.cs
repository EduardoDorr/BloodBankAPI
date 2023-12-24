using BloodBank.Domain.ValueObjects;

namespace BloodBank.Domain.Entities;

public class Donation : BaseEntity
{
    public int DonorId { get; private set; }
    public DateTime DonationDate { get; private set; }
    public BloodData BloodData { get; private set; }
    public int AmountInML { get; private set; }

    public virtual Donor? Donor { get; private set; }
    
    public static int MinimumAmount => 420;
    public static int MaximumAmount => 470;

    protected Donation() { }

    public Donation(Donor donor, int amountInML)
    {
        if (!ValidateAmountOfBlood(amountInML))
            throw new ArgumentOutOfRangeException($"The amount of blood must be between {MinimumAmount} and {MaximumAmount} mL");

        DonorId = donor.Id;
        BloodData = donor.BloodData;
        DonationDate = DateTime.Now;
        AmountInML = amountInML;

        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsActive = true;
    }

    public void Update(DateTime donationDate, int amountInML, bool isActive)
    {
        if (!ValidateAmountOfBlood(amountInML))
            throw new ArgumentOutOfRangeException($"The amount of blood must be between {MinimumAmount} and {MaximumAmount} mL");

        DonationDate = donationDate;
        AmountInML = amountInML;

        UpdatedAt = DateTime.Now;
        IsActive = isActive;
    }

    public void SetDonationDate(DateTime donationDate) => DonationDate = donationDate;

    private static bool ValidateAmountOfBlood(int amount)
    {
        return amount >= MinimumAmount &&
               amount <= MaximumAmount;
    }
}