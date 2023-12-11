using AutoMapper;

using BloodBank.Domain.Entities;
using BloodBank.Application.Donors.Read;
using BloodBank.Application.Donors.Update;
using BloodBank.Application.Donors.Create;

namespace BloodBank.Application.Donors.Profiles;

public class DonorProfile : Profile
{
    public DonorProfile()
    {
        CreateMap<CreateDonorModel, Donor>();
        CreateMap<UpdateDonorModel, Donor>();
        CreateMap<Donor, ReadDonorModel>();
        CreateMap<Donor, ReadDonorWithDonationsModel>();
    }
}