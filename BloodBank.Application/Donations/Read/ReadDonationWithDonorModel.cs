using BloodBank.Application.Donors.Read;

namespace BloodBank.Application.Donations.Read;

public record ReadDonationWithDonorModel(int Id, DateTime DonationDate, int AmountInML, ReadDonorModel Donor, bool IsActive);