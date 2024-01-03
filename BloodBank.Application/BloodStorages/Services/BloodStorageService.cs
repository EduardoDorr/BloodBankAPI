using BloodBank.Domain.Entities;
using BloodBank.Domain.Interfaces;
using BloodBank.Domain.ValueObjects;

namespace BloodBank.Application.BloodStorages.Services;

public class BloodStorageService : IBloodStorageService
{
    private readonly IBloodStorageRepository _bloodStorageRepository;

    public BloodStorageService(IBloodStorageRepository bloodStorageRepository)
    {
        _bloodStorageRepository = bloodStorageRepository;
    }

    public async Task AddAmount(BloodData bloodData, int amountInML)
    {
        var stockOfBlood = await GetByBloodTypeAsync(bloodData);

        if (stockOfBlood is null)
        {
            stockOfBlood = new BloodStorage(bloodData, amountInML);

            _bloodStorageRepository.Create(stockOfBlood);

            return;
        }

        stockOfBlood.AddAmount(amountInML);

        _bloodStorageRepository.Update(stockOfBlood);
    }

    public async Task WithdrawAmount(BloodData bloodData, int amountInML)
    {
        var stockOfBlood = await GetByBloodTypeAsync(bloodData);

        if (stockOfBlood is null)
            throw new Exception($"The blood type {bloodData.BloodType} {bloodData.RhFactor} does not exist in the storage");

        var withdrawed = stockOfBlood.WithdrawAmount(amountInML);

        if (!withdrawed)
            throw new Exception($"The blood type {bloodData.BloodType} {bloodData.RhFactor} does not have enough stock in the storage");

        _bloodStorageRepository.Update(stockOfBlood);
    }

    private async Task<BloodStorage?> GetByBloodTypeAsync(BloodData bloodData)
    {
        var stockOfBlood = await _bloodStorageRepository.GetByBloodTypeAsync(bloodData.BloodType, bloodData.RhFactor);

        return stockOfBlood;
    }
}
