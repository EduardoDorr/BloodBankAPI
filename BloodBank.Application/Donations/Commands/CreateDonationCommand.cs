using MediatR;

namespace BloodBank.Application.Donations.Commands;

public sealed record CreateDonationCommand(int DonorId, DateTime DonationDate, int AmountInML) : IRequest<int>;