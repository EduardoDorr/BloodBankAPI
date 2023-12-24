using MediatR;

using BloodBank.Application.Donations.Models;

namespace BloodBank.Application.Donations.Queries;

public sealed record GetReportOfDonationQuery(int NumberOfDays = 30) : IRequest<IEnumerable<GetDonationWithDonorViewModel>>;