using BloodBank.Domain.ValueObjects;

namespace BloodBank.Application.Donors.Create;

public record CreateDonorModel(string Name, string Email, DateTime BirthDate, string Gender, double Weight, string BloodType, string RhFactor, Address Address);