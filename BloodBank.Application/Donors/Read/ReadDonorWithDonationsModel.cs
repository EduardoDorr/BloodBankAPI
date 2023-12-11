using BloodBank.Domain.ValueObjects;
using BloodBank.Application.Donations.Read;

namespace BloodBank.Application.Donors.Read;

public record ReadDonorWithDonationsModel(int Id, string Name, string Email,
                                          DateTime BirthDate, string Gender, double Weight,
                                          BloodData BloodData, Address Address,
                                          ICollection<ReadDonationModel> Donations, bool IsActive);