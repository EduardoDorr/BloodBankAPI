namespace BloodBank.Application.Donations.Read;

public record ReadDonationModel(int Id, int DonorId, DateTime DonationDate, int AmountInML, bool IsActive);