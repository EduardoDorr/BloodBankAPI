namespace BloodBank.Application.Donations.Update;

public record UpdateDonationInputModel(int DonorId, DateTime DonationDate, int AmountInML, bool IsActive);