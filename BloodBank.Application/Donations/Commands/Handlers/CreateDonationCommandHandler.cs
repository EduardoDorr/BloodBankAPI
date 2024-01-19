using MediatR;

using BloodBank.Domain.Interfaces;
using BloodBank.Domain.DomainResults;
using BloodBank.Domain.DomainServices;
using BloodBank.Application.BloodStorages.Services;
using BloodBank.Domain.DomainErrors;

namespace BloodBank.Application.Donations.Commands.Handlers;

internal sealed class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, Result<int>>
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

    public async Task<Result<int>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
    {
        var donor = await _donorRepository.GetWithDonationsByIdAsync(request.DonorId, 1);

        if (donor is null || !donor.IsActive)
            return DonorErrors.NotFound;

        var donationResult = _donationService.CreateDonation(donor, request.DonationDate, request.AmountInML);

        if (!donationResult.Success)
            return Result<int>.Fail(donationResult.Errors);

        var donation = donationResult.Value;

        _donationRepository.Create(donation);

        await _bloodStorageService.AddAmount(donation.BloodData,
                                             donation.AmountInML);

        var created = await _donationRepository.SaveChangesAsync();

        if (!created)
            return DonationErrors.CannotBeCreated;

        return donation.Id;
    }
}