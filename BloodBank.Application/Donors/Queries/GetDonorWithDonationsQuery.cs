using MediatR;

using BloodBank.Application.Donors.Models;

namespace BloodBank.Application.Donors.Queries;

public sealed record GetDonorWithDonationsQuery(int Id, int Take = 50) : IRequest<GetDonorWithDonationsViewModel?>;