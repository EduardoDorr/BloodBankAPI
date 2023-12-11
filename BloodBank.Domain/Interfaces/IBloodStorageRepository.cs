using BloodBank.Domain.Entities;
using BloodBank.Domain.ValueObjects;

namespace BloodBank.Domain.Interfaces;

public interface IBloodStorageRepository : IRepository<BloodStorage>
{
    Task<BloodStorage?> GetByBloodTypeAsync(BloodType bloodType, RhFactor rhFactor);
}