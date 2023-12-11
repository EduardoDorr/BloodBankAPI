using BloodBank.Domain.ValueObjects;

namespace BloodBank.Domain.Entities;

public class Donation : BaseEntity
{
    public int DonorId { get; private set; }
    public DateTime DonationDate { get; private set; }
    public BloodData BloodData { get; private set; }
    public int AmountInML { get; private set; }

    public virtual Donor? Donor { get; set; }

    protected Donation() { }

    public Donation(Donor donor, int amountInML)
    {
        if (!ValidateAmountOfBlood(amountInML))
            throw new ArgumentOutOfRangeException($"The amount of blood must be between 420 and 470 mL");

        DonorId = donor.Id;
        BloodData = donor.BloodData;
        DonationDate = DateTime.Now;
        AmountInML = amountInML;

        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsActive = true;
    }

    public void Update(Donor donor, DateTime donationDate, int amountInML, bool isActive)
    {
        DonorId = donor.Id;
        DonationDate = donationDate;
        BloodData = donor.BloodData;
        AmountInML = amountInML;

        UpdatedAt = DateTime.Now;
        IsActive = isActive;
    }

    public void SetDonationDate(DateTime donationDate) => DonationDate = donationDate;

    private static bool ValidateAmountOfBlood(int amount)
    {
        return amount >= 420 &&
               amount <= 470;
    }
}