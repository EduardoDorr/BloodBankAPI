using BloodBank.Application.Donors.Create;
using BloodBank.Application.Donors.Read;
using BloodBank.Application.Donors.Update;

namespace BloodBank.Application.Donors.Services;

public interface IDonorService
{
    Task<IEnumerable<ReadDonorModel>> GetAllAsync(int skip = 0, int take = 50);
    Task<ReadDonorModel?> GetByIdAsync(int id);
    Task<ReadDonorWithDonationsModel?> GetWithDonationsByIdAsync(int id, int take = 50);
    Task<ReadDonorWithDonationsModel?> GetWithLastDonationByIdAsync(int id);
    Task<int> CreateAsync(CreateDonorModel donorInputModel);
    Task<bool> UpdateAsync(int id, UpdateDonorModel donorInputModel);
}