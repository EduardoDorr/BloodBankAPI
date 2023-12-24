using MediatR;
using AutoMapper;

using BloodBank.Domain.Interfaces;
using BloodBank.Application.Donations.Models;

namespace BloodBank.Application.Donations.Queries.Handlers;

internal sealed class GetDonationQueryHandler : IRequestHandler<GetDonationQuery, GetDonationViewModel?>
{
    private readonly IDonationRepository _donationRepository;
    private readonly IMapper _mapper;

    public GetDonationQueryHandler(IDonationRepository donationRepository, IMapper mapper)
    {
        _donationRepository = donationRepository;
        _mapper = mapper;
    }

    public async Task<GetDonationViewModel?> Handle(GetDonationQuery request, CancellationToken cancellationToken)
    {
        var donation = await _donationRepository.GetByIdAsync(request.Id);

        return _mapper.Map<GetDonationViewModel>(donation);
    }
}