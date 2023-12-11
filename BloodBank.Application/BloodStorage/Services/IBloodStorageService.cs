using BloodBank.Domain.ValueObjects;

namespace BloodBank.Application.BloodStorage.Services;

public interface IBloodStorageService
{
    Task<IEnumerable<Domain.Entities.BloodStorage>> GetAllAsync(int skip = 0, int take = 50);
    Task<Domain.Entities.BloodStorage?> GetByIdAsync(int id);
    Task<Domain.Entities.BloodStorage?> GetByBloodTypeAsync(string bloodType, string rhFactor);
    Task<Domain.Entities.BloodStorage?> GetByBloodTypeAsync(BloodData bloodData);
    Task AddAmount(string bloodType, string rhFactor, int amountInML);
    Task AddAmount(BloodData bloodData, int amountInML);
    Task WithdrawAmount(string bloodType, string rhFactor, int amountInML);
}