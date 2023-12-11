using BloodBank.Domain.ValueObjects;

namespace BloodBank.Application.Donors.Read;

public record ReadDonorModel(int Id, string Name, string Email, DateTime BirthDate, string Gender, double Weight, BloodData BloodData, Address Address, bool IsActive);