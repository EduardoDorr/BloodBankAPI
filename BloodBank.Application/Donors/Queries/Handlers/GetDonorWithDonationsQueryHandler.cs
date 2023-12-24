using MediatR;
using AutoMapper;

using BloodBank.Domain.Interfaces;
using BloodBank.Application.Donors.Models;

namespace BloodBank.Application.Donors.Queries.Handlers;

internal sealed class GetDonorWithDonationsQueryHandler : IRequestHandler<GetDonorWithDonationsQuery, GetDonorWithDonationsViewModel?>
{
    private readonly IDonorRepository _donorRepository;
    private readonly IMapper _mapper;

    public GetDonorWithDonationsQueryHandler(IDonorRepository donorRepository, IMapper mapper)
    {
        _donorRepository = donorRepository;
        _mapper = mapper;
    }

    public async Task<GetDonorWithDonationsViewModel?> Handle(GetDonorWithDonationsQuery request, CancellationToken cancellationToken)
    {
        var donor = await _donorRepository.GetWithDonationsByIdAsync(request.Id, request.Take);

        return _mapper.Map<GetDonorWithDonationsViewModel>(donor);
    }
}