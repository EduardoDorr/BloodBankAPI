namespace BloodBank.Domain.Entities;

public class Donor : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }
    public double Weight { get; set; }
    public string BloodType { get; set; }
    public string RhFactor { get; set; }
    public int AddressId { get; set; }

    public virtual Address? Address { get; set; }
    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public Donor(string name, string email, DateTime birthDate, string gender, double weight, string bloodType, string rhFactor, int addressId)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RhFactor = rhFactor;
        AddressId = addressId;

        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsActive = true;
    }

    public void Update(string name, DateTime birthDate, string gender, double weight, string bloodType, string rhFactor, int addressId, bool isActive)
    {
        Name = name;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RhFactor = rhFactor;
        AddressId = addressId;

        UpdatedAt = DateTime.Now;
        IsActive = isActive;
    }

    public bool CanDonate()
    {
        var dateTime18YearsAgo = DateTime.Today.AddYears(-18);

        return dateTime18YearsAgo >= BirthDate.Date;
    }

    public bool HasMinimumWeight()
    {
        return Weight >= 50;
    }
}