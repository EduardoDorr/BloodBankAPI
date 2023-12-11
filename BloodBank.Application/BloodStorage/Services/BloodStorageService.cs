using AutoMapper;
using BloodBank.Domain.Interfaces;
using BloodBank.Domain.ValueObjects;

namespace BloodBank.Application.BloodStorage.Services;

public class BloodStorageService : IBloodStorageService
{
    private readonly IBloodStorageRepository _bloodStorageRepository;
    private readonly IMapper _mapper;

    public BloodStorageService(IBloodStorageRepository bloodStorageRepository, IMapper mapper)
    {
        _bloodStorageRepository = bloodStorageRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Domain.Entities.BloodStorage>> GetAllAsync(int skip = 0, int take = 50)
    {
        var stockOfBloods = await _bloodStorageRepository.GetAllAsync(skip, take);

        return stockOfBloods;
    }

    public async Task<Domain.Entities.BloodStorage?> GetByIdAsync(int id)
    {
        var stockOfBlood = await _bloodStorageRepository.GetByIdAsync(id);

        return stockOfBlood;
    }

    public async Task<Domain.Entities.BloodStorage?> GetByBloodTypeAsync(string bloodType, string rhFactor)
    {
        var bloodData = new BloodData(bloodType, rhFactor);

        var stockOfBlood = await _bloodStorageRepository.GetByBloodTypeAsync(bloodData.BloodType, bloodData.RhFactor);

        return stockOfBlood;
    }

    public async Task<Domain.Entities.BloodStorage?> GetByBloodTypeAsync(BloodData bloodData)
    {
        var stockOfBlood = await _bloodStorageRepository.GetByBloodTypeAsync(bloodData.BloodType, bloodData.RhFactor);

        return stockOfBlood;
    }

    public async Task AddAmount(string bloodType, string rhFactor, int amountInML)
    {
        var bloodData = new BloodData(bloodType, rhFactor);

        var stockOfBlood = await GetByBloodTypeAsync(bloodData);

        if (stockOfBlood is null)
        {
            stockOfBlood = new Domain.Entities.BloodStorage(bloodData, amountInML);

            _bloodStorageRepository.Create(stockOfBlood);
        }

        stockOfBlood.AddAmount(amountInML);

        _bloodStorageRepository.Update(stockOfBlood);
    }

    public async Task AddAmount(BloodData bloodData, int amountInML)
    {
        var stockOfBlood = await GetByBloodTypeAsync(bloodData);

        if (stockOfBlood is null)
        {
            stockOfBlood = new Domain.Entities.BloodStorage(bloodData, amountInML);

            _bloodStorageRepository.Create(stockOfBlood);

            return;
        }

        stockOfBlood.AddAmount(amountInML);

        _bloodStorageRepository.Update(stockOfBlood);
    }

    public Task WithdrawAmount(string bloodType, string rhFactor, int amountInML)
    {
        throw new NotImplementedException();
    }
}
