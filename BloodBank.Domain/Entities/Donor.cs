using BloodBank.Domain.Enums;
using BloodBank.Domain.ValueObjects;
using BloodBank.Domain.DomainResults;
using BloodBank.Domain.DomainErrors;

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

    private const int _minimumWeightToDonate = 50;
    private const int _dayBetweenDonationsMale = 60;
    private const int _dayBetweenDonationsFemale = 90;

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

    public Result CanDonate()
    {
        if (IsMinor())
            return Result.Fail(DonorErrors.IsMinor);

        if (!VerifyTimeBetweenDonations())
            return Result.Fail(DonorErrors.DonatedRecently);

        return Result.Ok();
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

    private bool VerifyTimeBetweenDonations()
    {
        if (!Donations.Any())
            return true;

        var date = DateTime.Today;
        var lastDonationDate = Donations.OrderBy(d => d.DonationDate)
                                        .Last().DonationDate;

        return Gender.Type switch
        {
            GenderType.Male => lastDonationDate < date.AddDays(-_dayBetweenDonationsMale),
            GenderType.Female => lastDonationDate < date.AddDays(-_dayBetweenDonationsFemale),
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
        return weight >= _minimumWeightToDonate;
    }
}