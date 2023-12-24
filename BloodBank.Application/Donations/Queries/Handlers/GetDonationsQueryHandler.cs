using MediatR;
using AutoMapper;

using BloodBank.Domain.Interfaces;
using BloodBank.Application.Donations.Models;

namespace BloodBank.Application.Donations.Queries.Handlers;

internal sealed class GetDonationsQueryHandler : IRequestHandler<GetDonationsQuery, IEnumerable<GetDonationViewModel>>
{
    private readonly IDonationRepository _donationRepository;
    private readonly IMapper _mapper;

    public GetDonationsQueryHandler(IDonationRepository donationRepository, IMapper mapper)
    {
        _donationRepository = donationRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetDonationViewModel>> Handle(GetDonationsQuery request, CancellationToken cancellationToken)
    {
        var donations = await _donationRepository.GetAllAsync(request.Skip, request.Take);

        return _mapper.Map<IEnumerable<GetDonationViewModel>>(donations);
    }
}