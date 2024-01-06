using MediatR;

using BloodBank.Domain.DomainResults;

namespace BloodBank.Application.Donations.Commands;

public sealed record CreateDonationCommand(int DonorId, DateTime DonationDate, int AmountInML) : IRequest<Result<int>>;