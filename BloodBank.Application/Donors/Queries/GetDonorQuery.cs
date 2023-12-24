using MediatR;

using BloodBank.Application.Donors.Models;

namespace BloodBank.Application.Donors.Queries;

public sealed record GetDonorQuery(int Id) : IRequest<GetDonorViewModel>;