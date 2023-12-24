using MediatR;

using BloodBank.Domain.Entities;
using BloodBank.Domain.Interfaces;
using BloodBank.Domain.ValueObjects;

namespace BloodBank.Application.BloodStorages.Queries.Handlers;

internal sealed class GetBloodTypeStorageQueryHandler : IRequestHandler<GetBloodTypeStorageQuery, BloodStorage?>
{
    private readonly IBloodStorageRepository _bloodStorageRepository;

    public GetBloodTypeStorageQueryHandler(IBloodStorageRepository bloodStorageRepository)
    {
        _bloodStorageRepository = bloodStorageRepository;
    }

    public async Task<BloodStorage?> Handle(GetBloodTypeStorageQuery request, CancellationToken cancellationToken)
    {
        var bloodData = new BloodData(request.BloodType, request.RhFactor);

        var stockOfBlood = await _bloodStorageRepository.GetByBloodTypeAsync(bloodData.BloodType, bloodData.RhFactor);

        return stockOfBlood;
    }
}