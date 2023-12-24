using MediatR;

using BloodBank.Domain.Entities;

namespace BloodBank.Application.BloodStorages.Queries;

public sealed record GetBloodStorageQuery(int Id) : IRequest<BloodStorage?>;