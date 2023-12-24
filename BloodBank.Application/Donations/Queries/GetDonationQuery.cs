using MediatR;

using BloodBank.Application.Donations.Models;

namespace BloodBank.Application.Donations.Queries;

public sealed record GetDonationQuery(int Id) : IRequest<GetDonationViewModel?>;