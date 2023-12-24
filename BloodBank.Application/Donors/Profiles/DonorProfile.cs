using AutoMapper;

using BloodBank.Domain.Entities;
using BloodBank.Application.Donors.Models;

namespace BloodBank.Application.Donors.Profiles;

public class DonorProfile : Profile
{
    public DonorProfile()
    {
        CreateMap<Donor, GetDonorViewModel>();
        CreateMap<Donor, GetDonorWithDonationsViewModel>();
    }
}