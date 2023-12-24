using MediatR;
using AutoMapper;

using BloodBank.Domain.Interfaces;
using BloodBank.Application.Donors.Models;

namespace BloodBank.Application.Donors.Queries.Handlers;

internal sealed class GetDonorQueryHandler : IRequestHandler<GetDonorQuery, GetDonorViewModel>
{
    private readonly IDonorRepository _donorRepository;
    private readonly IMapper _mapper;

    public GetDonorQueryHandler(IDonorRepository donorRepository, IMapper mapper)
    {
        _donorRepository = donorRepository;
        _mapper = mapper;
    }

    public async Task<GetDonorViewModel> Handle(GetDonorQuery request, CancellationToken cancellationToken)
    {
        var donor = await _donorRepository.GetByIdAsync(request.Id);

        return _mapper.Map<GetDonorViewModel>(donor);
    }
}
