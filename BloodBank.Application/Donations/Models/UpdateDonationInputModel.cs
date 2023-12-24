namespace BloodBank.Application.Donations.Models;

public record UpdateDonationInputModel(DateTime DonationDate, int AmountInML, bool IsActive);