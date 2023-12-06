namespace BloodBank.Domain.Entities;

public class Address : BaseEntity
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }

    public virtual ICollection<Donor> Donors { get; set; }

    public Address(string street, string city, string state, string postalCode)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;

        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsActive = true;
    }

    public void Update(string street, string city, string state, string postalCode, bool isActive)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;

        UpdatedAt = DateTime.Now;
        IsActive = isActive;
    }
}