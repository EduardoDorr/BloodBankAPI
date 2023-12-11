using AutoMapper;

using BloodBank.Domain.Entities;
using BloodBank.Domain.Interfaces;
using BloodBank.Application.Donors.Read;
using BloodBank.Application.Donors.Update;
using BloodBank.Application.Donors.Create;

namespace BloodBank.Application.Donors.Services;

public class DonorService : IDonorService
{
    private readonly IDonorRepository _donorRepository;
    private readonly IMapper _mapper;

    public DonorService(IDonorRepository donorRepository, IMapper mapper)
    {
        _donorRepository = donorRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadDonorModel>> GetAllAsync(int skip = 0, int take = 50)
    {
        var donors = await _donorRepository.GetAllAsync(skip, take);

        return _mapper.Map<IEnumerable<ReadDonorModel>>(donors);
    }

    public async Task<ReadDonorModel?> GetByIdAsync(int id)
    {
        var donor = await _donorRepository.GetByIdAsync(id);

        return _mapper.Map<ReadDonorModel>(donor);
    }
    public async Task<ReadDonorWithDonationsModel?> GetWithDonationsByIdAsync(int id, int take)
    {
        var donor = await _donorRepository.GetWithDonationsByIdAsync(id, take);

        return _mapper.Map<ReadDonorWithDonationsModel>(donor);
    }

    public async Task<ReadDonorWithDonationsModel?> GetWithLastDonationByIdAsync(int id)
    {
        var donor = await _donorRepository.GetWithDonationsByIdAsync(id, 1);

        return _mapper.Map<ReadDonorWithDonationsModel>(donor);
    }

    public async Task<int> CreateAsync(CreateDonorModel donorInputModel)
    {
        var donor = _mapper.Map<Donor>(donorInputModel);

        _donorRepository.Create(donor);

        var created = await _donorRepository.SaveChangesAsync();

        if (!created)
            throw new Exception("Donor could not be created");

        return donor.Id;
    }

    public async Task<bool> UpdateAsync(int id, UpdateDonorModel donorInputModel)
    {
        var donorToUpdate = await _donorRepository.GetByIdAsync(id);

        if (donorToUpdate is null)
            return false;

        donorToUpdate.Update(donorInputModel.Name, donorInputModel.Email,
                             donorInputModel.BirthDate, donorInputModel.Gender,
                             donorInputModel.Weight, donorInputModel.BloodType,
                             donorInputModel.RhFactor, donorInputModel.Address,
                             donorInputModel.IsActive);

        _donorRepository.Update(donorToUpdate);

        return await _donorRepository.SaveChangesAsync();
    }
}