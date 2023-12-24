using MediatR;
using AutoMapper;

using BloodBank.Domain.Interfaces;
using BloodBank.Application.Donors.Models;

namespace BloodBank.Application.Donors.Queries.Handlers;

internal sealed class GetDonorsQueryHandler : IRequestHandler<GetDonorsQuery, IEnumerable<GetDonorViewModel>>
{
    private readonly IDonorRepository _donorRepository;
    private readonly IMapper _mapper;

    public GetDonorsQueryHandler(IDonorRepository donorRepository, IMapper mapper)
    {
        _donorRepository = donorRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetDonorViewModel>> Handle(GetDonorsQuery request, CancellationToken cancellationToken)
    {
        var donors = await _donorRepository.GetAllAsync(request.Skip, request.Take);

        return _mapper.Map<IEnumerable<GetDonorViewModel>>(donors);
    }
}