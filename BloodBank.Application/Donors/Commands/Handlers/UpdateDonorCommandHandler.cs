using MediatR;
using AutoMapper;

using BloodBank.Domain.Interfaces;
using BloodBank.Domain.ValueObjects;

namespace BloodBank.Application.Donors.Commands.Handlers;

internal sealed class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, bool>
{
    private readonly IDonorRepository _donorRepository;
    private readonly IMapper _mapper;

    public UpdateDonorCommandHandler(IDonorRepository donorRepository, IMapper mapper)
    {
        _donorRepository = donorRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
    {
        var donorToUpdate = await _donorRepository.GetByIdAsync(request.Id);
        var address = _mapper.Map<Address>(request.Donor.Address);

        if (donorToUpdate is null)
            return false;

        donorToUpdate.Update(request.Donor.Name, request.Donor.Email,
                             request.Donor.BirthDate, request.Donor.Gender,
                             request.Donor.Weight, request.Donor.BloodType,
                             request.Donor.RhFactor, address,
                             request.Donor.IsActive);

        _donorRepository.Update(donorToUpdate);

        return await _donorRepository.SaveChangesAsync();
    }
}