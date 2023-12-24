using BloodBank.Application.Addresses.Models;

namespace BloodBank.Application.Donors.Models;

public sealed record UpdateDonorInputModel(string Name, string Email, DateTime BirthDate, string Gender, double Weight, string BloodType, string RhFactor, AddressModel Address, bool IsActive);