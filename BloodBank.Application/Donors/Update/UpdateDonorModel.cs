using BloodBank.Domain.ValueObjects;

namespace BloodBank.Application.Donors.Update;

public record UpdateDonorModel(string Name, string Email, DateTime BirthDate, string Gender, double Weight, string BloodType, string RhFactor, Address Address, bool IsActive);