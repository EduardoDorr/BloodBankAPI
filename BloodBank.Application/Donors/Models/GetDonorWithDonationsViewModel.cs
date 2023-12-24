using BloodBank.Domain.ValueObjects;
using BloodBank.Application.Donations.Models;

namespace BloodBank.Application.Donors.Models;

public record GetDonorWithDonationsViewModel(int Id, string Name, string Email,
                                             DateTime BirthDate, string Gender, double Weight,
                                             BloodData BloodData, Address Address,
                                             ICollection<GetDonationViewModel> Donations, bool IsActive);