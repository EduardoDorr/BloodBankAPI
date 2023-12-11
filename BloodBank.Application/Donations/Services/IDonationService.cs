using BloodBank.Application.Donations.Create;
using BloodBank.Application.Donations.Update;
using BloodBank.Application.Donations.Read;

namespace BloodBank.Application.Donations.Services;

public interface IDonationService
{
    Task<IEnumerable<ReadDonationModel>> GetAllAsync(int skip = 0, int take = 50);
    Task<ReadDonationModel?> GetByIdAsync(int id);
    Task<IEnumerable<ReadDonationWithDonorModel?>> GetReportWithDonorsAsync(int numberOfDays);
    Task<int> CreateAsync(CreateDonationInputModel donationInputModel);
    Task<bool> UpdateAsync(int id, UpdateDonationInputModel donationInputModel);
}