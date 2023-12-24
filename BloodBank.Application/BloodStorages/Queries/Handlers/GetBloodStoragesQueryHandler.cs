using MediatR;

using BloodBank.Domain.Entities;
using BloodBank.Domain.Interfaces;

namespace BloodBank.Application.BloodStorages.Queries.Handlers;

internal sealed class GetBloodStoragesQueryHandler : IRequestHandler<GetBloodStoragesQuery, IEnumerable<BloodStorage>>
{
    private readonly IBloodStorageRepository _bloodStorageRepository;

    public GetBloodStoragesQueryHandler(IBloodStorageRepository bloodStorageRepository)
    {
        _bloodStorageRepository = bloodStorageRepository;
    }

    public async Task<IEnumerable<BloodStorage>> Handle(GetBloodStoragesQuery request, CancellationToken cancellationToken)
    {
        var stockOfBloods = await _bloodStorageRepository.GetAllAsync(request.Skip, request.Take);

        return stockOfBloods;
    }
}