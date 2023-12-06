namespace BloodBank.Domain.Entities;

public class Donation : BaseEntity
{
    public int DonorId { get; set; }
    public DateTime DonationDate { get; set; }
    public string BloodType { get; set; }
    public string RhFactor { get; set; }
    public int AmountInML { get; set; }

    public virtual Donor? Donor { get; set; }

    private Donation(Donor donor, DateTime donationDate, int amountInML)
    {
        DonorId = donor.Id;
        DonationDate = donationDate;
        BloodType = donor.BloodType;
        RhFactor = donor.RhFactor;
        AmountInML = amountInML;

        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsActive = true;
    }

    public Donation? Create(Donor donor, DateTime donationDate, int amountInML)
    {
        if (!ValidateAmountOfBlood(amountInML))
            return null;

        return new Donation(donor, donationDate, amountInML);
    }

    public void Update(Donor donor, DateTime donationDate, int amountInML, bool isActive)
    {
        DonorId = donor.Id;
        DonationDate = donationDate;
        BloodType = donor.BloodType;
        RhFactor = donor.RhFactor;
        AmountInML = amountInML;

        UpdatedAt = DateTime.Now;
        IsActive = isActive;
    }

    public bool ValidateAmountOfBlood(int amount)
    {
        return amount >= 420 &&
               amount <= 470;
    }
}