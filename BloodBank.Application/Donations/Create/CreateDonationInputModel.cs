namespace BloodBank.Application.Donations.Create;

public record CreateDonationInputModel(int DonorId, DateTime DonationDate, int AmountInML);