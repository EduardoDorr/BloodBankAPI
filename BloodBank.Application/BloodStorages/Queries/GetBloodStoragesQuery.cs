using MediatR;

using BloodBank.Domain.Entities;

namespace BloodBank.Application.BloodStorages.Queries;

public sealed record GetBloodStoragesQuery(int Skip = 0, int Take = 50) : IRequest<IEnumerable<BloodStorage>>;