using BloodBank.Domain.ValueObjects;

namespace BloodBank.Application.Donors.Models;

public record GetDonorViewModel(int Id, string Name, string Email, DateTime BirthDate, string Gender, double Weight, BloodData BloodData, Address Address, bool IsActive);