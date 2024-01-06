using AutoMapper;

using BloodBank.Domain.Entities;
using BloodBank.Application.Donors.Models;
using BloodBank.Application.Donors.Commands;

namespace BloodBank.Application.Donors.Profiles;

public class DonorProfile : Profile
{
    public DonorProfile()
    {
        CreateMap<CreateDonorCommand, Donor>();
        CreateMap<Donor, GetDonorViewModel>();
        CreateMap<Donor, GetDonorWithDonationsViewModel>();
    }
}