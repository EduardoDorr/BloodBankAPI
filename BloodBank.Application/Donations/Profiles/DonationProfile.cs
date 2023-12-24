using AutoMapper;

using BloodBank.Domain.Entities;
using BloodBank.Application.Donations.Models;

namespace BloodBank.Application.Donations.Profiles;

public class DonationProfile : Profile
{
    public DonationProfile()
    {
        CreateMap<Donation, GetDonationViewModel>();
        CreateMap<Donation, GetDonationWithDonorViewModel>();
    }
}