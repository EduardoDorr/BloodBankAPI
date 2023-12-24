using MediatR;

using BloodBank.Application.Donations.Models;

namespace BloodBank.Application.Donations.Commands;

public sealed record UpdateDonationCommand(int Id, UpdateDonationInputModel Donation) : IRequest<bool>;