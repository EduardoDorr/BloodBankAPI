using MediatR;

using BloodBank.Domain.Entities;

namespace BloodBank.Application.BloodStorages.Queries;

public sealed record GetBloodTypeStorageQuery(string BloodType, string RhFactor) : IRequest<BloodStorage?>;