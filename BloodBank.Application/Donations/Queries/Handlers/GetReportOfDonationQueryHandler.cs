using MediatR;
using AutoMapper;

using BloodBank.Domain.Interfaces;
using BloodBank.Application.Donations.Models;

namespace BloodBank.Application.Donations.Queries.Handlers;

internal sealed class GetReportOfDonationQueryHandler : IRequestHandler<GetReportOfDonationQuery, IEnumerable<GetDonationWithDonorViewModel>>
{
    private readonly IDonationRepository _donationRepository;
    private readonly IMapper _mapper;

    public GetReportOfDonationQueryHandler(IDonationRepository donationRepository, IMapper mapper)
    {
        _donationRepository = donationRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetDonationWithDonorViewModel>> Handle(GetReportOfDonationQuery request, CancellationToken cancellationToken)
    {
        var donation = await _donationRepository.GetReportWithDonorsAsync(request.NumberOfDays);

        return _mapper.Map<IEnumerable<GetDonationWithDonorViewModel>>(donation);
    }
}