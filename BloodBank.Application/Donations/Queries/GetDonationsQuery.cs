using MediatR;

using BloodBank.Application.Donations.Models;

namespace BloodBank.Application.Donations.Queries;

public sealed record GetDonationsQuery(int Skip = 0, int Take = 50) : IRequest<IEnumerable<GetDonationViewModel>>;