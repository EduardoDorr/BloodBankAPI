using BloodBank.Domain.Entities;

namespace BloodBank.Domain.Interfaces;

public interface IDonorRepository : IRepository<Donor>
{
    Task<Donor?> GetWithDonationsByIdAsync(int id, int take = 50);
    Task<bool> IsEmailUniqueAsync(string email);
}