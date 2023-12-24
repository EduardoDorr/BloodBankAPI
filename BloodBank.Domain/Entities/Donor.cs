using BloodBank.Domain.Enums;
using BloodBank.Domain.ValueObjects;

namespace BloodBank.Domain.Entities;

public class Donor : BaseEntity
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Gender Gender { get; private set; }
    public double Weight { get; private set; }
    public BloodData BloodData { get; private set; }
    public Address Address { get; private set; }

    public virtual ICollection<Donation> Donations { get; private set; } = new List<Donation>();

    protected Donor() { }

    public Donor(string name, string email, DateTime birthDate, string gender, double weight, string bloodType, string rhFactor, Address address)
    {
        if (!HasMinimumWeight(weight))
            throw new ArgumentException($"Donor must weights at least 50kg");

        Name = name;
        Email = new Email(email);
        BirthDate = birthDate;
        Gender = new Gender(gender);
        Weight = weight;
        BloodData = new BloodData(bloodType, rhFactor);
        Address = address;

        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsActive = true;
    }

    public Donation Donate(int amountInML)
    {
        if (IsMinor())
            throw new Exception("Donor is minor and can't donate");

        if (!CanDonate())
            throw new Exception("Donor recently donated and can't donate");

        return new Donation(this, amountInML);
    }

    public void Update(string name, string email, DateTime birthDate, string gender, double weight, string bloodType, string rhFactor, Address address, bool isActive)
    {
        Name = name;
        Email = new Email(email);
        BirthDate = birthDate;
        Gender = new Gender(gender);
        Weight = weight;
        BloodData = new BloodData(bloodType, rhFactor);
        Address = address;

        UpdatedAt = DateTime.Now;
        IsActive = isActive;
    }

    private bool CanDonate()
    {
        if (!Donations.Any())
            return true;

        var date = DateTime.Today;
        var lastDonationDate = Donations.OrderBy(d => d.DonationDate)
                                        .Last().DonationDate;

        return Gender.Type switch
        {
            GenderType.Male => lastDonationDate < date.AddDays(-60),
            GenderType.Female => lastDonationDate < date.AddDays(-90),
            _ => false,
        };
    }

    private bool IsMinor()
    {
        var dateTime18YearsAgo = DateTime.Today.AddYears(-18);

        return BirthDate >= dateTime18YearsAgo;
    }

    private static bool HasMinimumWeight(double weight)
    {
        return weight >= 50;
    }
}