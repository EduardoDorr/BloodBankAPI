using AutoMapper;

using BloodBank.Domain.Entities;
using BloodBank.Application.Donations.Create;
using BloodBank.Application.Donations.Update;
using BloodBank.Application.Donations.Read;

namespace BloodBank.Application.Donations.Profiles;

public class DonationProfile : Profile
{
    public DonationProfile()
    {
        CreateMap<CreateDonationInputModel, Donation>();
        CreateMap<UpdateDonationInputModel, Donation>();
        CreateMap<Donation, ReadDonationModel>();
        CreateMap<Donation, ReadDonationWithDonorModel>();
    }
}