using MediatR;

using BloodBank.Application.Donors.Models;

namespace BloodBank.Application.Donors.Commands;

public sealed record UpdateDonorCommand(int Id, UpdateDonorInputModel Donor) : IRequest<bool>;