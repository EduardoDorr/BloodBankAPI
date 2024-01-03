using MediatR;

using BloodBank.Domain.Interfaces;
using BloodBank.Application.BloodStorages.Services;
using BloodBank.Domain.DomainServices;

namespace BloodBank.Application.Donations.Commands.Handlers;

internal sealed class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, int>
{
    private readonly IDonationService _donationService;
    private readonly IDonorRepository _donorRepository;
    private readonly IDonationRepository _donationRepository;
    private readonly IBloodStorageService _bloodStorageService;

    public CreateDonationCommandHandler(IDonationService donationService,
                                        IDonorRepository donorRepository,
                                        IDonationRepository donationRepository,
                                        IBloodStorageService bloodStorageService)
    {
        _donationService = donationService;
        _donorRepository = donorRepository;
        _donationRepository = donationRepository;
        _bloodStorageService = bloodStorageService;
    }

    public async Task<int> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
    {
        var donor = await _donorRepository.GetWithDonationsByIdAsync(request.DonorId, 1);

        if (donor is null || !donor.IsActive)
            throw new Exception("An active donor could not be found");

        var donation = _donationService.CreateDonation(donor, request.DonationDate, request.AmountInML);

        _donationRepository.Create(donation);

        await _bloodStorageService.AddAmount(donation.BloodData,
                                             donation.AmountInML);

        var created = await _donationRepository.SaveChangesAsync();

        if (!created)
            throw new Exception("Donation could not be created");

        return donation.Id;
    }
}