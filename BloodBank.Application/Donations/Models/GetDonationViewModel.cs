namespace BloodBank.Application.Donations.Models;

public record GetDonationViewModel(int Id, int DonorId, DateTime DonationDate, int AmountInML, bool IsActive);