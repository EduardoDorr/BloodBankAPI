using MediatR;

using BloodBank.Application.Addresses.Models;

namespace BloodBank.Application.Donors.Commands;

public sealed record CreateDonorCommand(string Name,
                                        string Email,
                                        DateTime BirthDate,
                                        string Gender,
                                        double Weight,
                                        string BloodType,
                                        string RhFactor,
                                        AddressModel Address) : IRequest<int>;