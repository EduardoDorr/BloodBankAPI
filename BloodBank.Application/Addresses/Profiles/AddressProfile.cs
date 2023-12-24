using AutoMapper;

using BloodBank.Domain.ValueObjects;
using BloodBank.Application.Addresses.Models;

namespace BloodBank.Application.Addresses.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, AddressModel>().ReverseMap();
    }
}