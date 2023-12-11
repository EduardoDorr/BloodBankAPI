using AutoMapper;

using BloodBank.Domain.Interfaces;
using BloodBank.Application.Donations.Read;
using BloodBank.Application.Donations.Update;
using BloodBank.Application.Donations.Create;
using BloodBank.Application.BloodStorage.Services;

namespace BloodBank.Application.Donations.Services;

public class DonationService : IDonationService
{
    private readonly IDonorRepository _donorRepository;
    private readonly IDonationRepository _donationRepository;
    private readonly IBloodStorageService _bloodStorageService;
    private readonly IMapper _mapper;

    public DonationService(IDonorRepository donorRepository, IDonationRepository donationRepository, IBloodStorageService bloodStorageService, IMapper mapper)
    {
        _donorRepository = donorRepository;
        _donationRepository = donationRepository;
        _bloodStorageService = bloodStorageService;
        _mapper = mapper;
    }

    //public DonationService(IDonorRepository donorRepository, IDonationRepository donationRepository, IMapper mapper)
    //{
    //    _donorRepository = donorRepository;
    //    _donationRepository = donationRepository;
    //    _mapper = mapper;
    //}

    public async Task<IEnumerable<ReadDonationModel>> GetAllAsync(int skip = 0, int take = 50)
    {
        var donations = await _donationRepository.GetAllAsync(skip, take);

        return _mapper.Map<IEnumerable<ReadDonationModel>>(donations);
    }

    public async Task<ReadDonationModel?> GetByIdAsync(int id)
    {
        var donation = await _donationRepository.GetByIdAsync(id);

        return _mapper.Map<ReadDonationModel>(donation);
    }

    public async Task<IEnumerable<ReadDonationWithDonorModel?>> GetReportWithDonorsAsync(int numberOfDays)
    {
        var donation = await _donationRepository.GetReportWithDonorsAsync(numberOfDays);

        return _mapper.Map<IEnumerable<ReadDonationWithDonorModel>>(donation);
    }

    public async Task<int> CreateAsync(CreateDonationInputModel donationInputModel)
    {
        var donor = await _donorRepository.GetWithDonationsByIdAsync(donationInputModel.DonorId, 1);

        if (donor is null || !donor.IsActive)
            throw new Exception("An active donor could not be found");

        var donation = donor.Donate(donationInputModel.AmountInML);

        _donationRepository.Create(donation);

        // Add Amount to Storage
        await _bloodStorageService.AddAmount(donation.BloodData,
                                             donation.AmountInML);

        var created = await _donationRepository.SaveChangesAsync();

        if (!created)
            throw new Exception("Donation could not be created");

        return donation.Id;
    }

    public async Task<bool> UpdateAsync(int id, UpdateDonationInputModel donationInputModel)
    {
        var donor = await _donorRepository.GetByIdAsync(donationInputModel.DonorId);

        if (donor is null || !donor.IsActive)
            throw new Exception("An active donor could not be found");

        var donationToUpdate = await _donationRepository.GetByIdAsync(id);

        if (donationToUpdate is null)
            return false;

        donationToUpdate.Update(donor, donationInputModel.DonationDate,
                                donationInputModel.AmountInML, donationInputModel.IsActive);

        _donationRepository.Update(donationToUpdate);

        return await _donationRepository.SaveChangesAsync();
    }
}
