using MediatR;

using BloodBank.Domain.Interfaces;
using BloodBank.Application.BloodStorages.Services;

namespace BloodBank.Application.Donations.Commands.Handlers;

internal sealed class UpdateDonationCommandHandler : IRequestHandler<UpdateDonationCommand, bool>
{
    private readonly IDonationRepository _donationRepository;
    private readonly IBloodStorageService _bloodStorageService;

    public UpdateDonationCommandHandler(IDonationRepository donationRepository, IBloodStorageService bloodStorageService)
    {
        _donationRepository = donationRepository;
        _bloodStorageService = bloodStorageService;
    }

    public async Task<bool> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
    {
        var donation = await _donationRepository.GetByIdAsync(request.Id);

        if (donation is null)
            return false;

        var lastAmount = donation.AmountInML;

        donation.Update(request.Donation.DonationDate,
                        request.Donation.AmountInML,
                        request.Donation.IsActive);

        if (lastAmount > donation.AmountInML)
            await _bloodStorageService.WithdrawAmount(donation.BloodData,
                                                      lastAmount - donation.AmountInML);
        else
            await _bloodStorageService.AddAmount(donation.BloodData,
                                                 donation.AmountInML - lastAmount);

        _donationRepository.Update(donation);

        return await _donationRepository.SaveChangesAsync();
    }
}