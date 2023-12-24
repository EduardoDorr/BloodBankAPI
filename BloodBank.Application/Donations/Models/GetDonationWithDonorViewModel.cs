using BloodBank.Application.Donors.Models;

namespace BloodBank.Application.Donations.Models;

public record GetDonationWithDonorViewModel(int Id, DateTime DonationDate, int AmountInML, GetDonorViewModel Donor, bool IsActive);