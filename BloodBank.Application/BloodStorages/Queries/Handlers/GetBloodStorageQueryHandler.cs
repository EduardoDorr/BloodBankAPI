using MediatR;

using BloodBank.Domain.Entities;
using BloodBank.Domain.Interfaces;

namespace BloodBank.Application.BloodStorages.Queries.Handlers;

internal sealed class GetBloodStorageQueryHandler : IRequestHandler<GetBloodStorageQuery, BloodStorage?>
{
    private readonly IBloodStorageRepository _bloodStorageRepository;

    public GetBloodStorageQueryHandler(IBloodStorageRepository bloodStorageRepository)
    {
        _bloodStorageRepository = bloodStorageRepository;
    }

    public async Task<BloodStorage?> Handle(GetBloodStorageQuery request, CancellationToken cancellationToken)
    {
        var stockOfBlood = await _bloodStorageRepository.GetByIdAsync(request.Id);

        return stockOfBlood;
    }
}
