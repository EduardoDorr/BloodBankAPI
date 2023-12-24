using MediatR;

using BloodBank.Application.Donors.Models;

namespace BloodBank.Application.Donors.Queries;

public sealed record GetDonorsQuery(int Skip = 0, int Take = 50) : IRequest<IEnumerable<GetDonorViewModel>>;