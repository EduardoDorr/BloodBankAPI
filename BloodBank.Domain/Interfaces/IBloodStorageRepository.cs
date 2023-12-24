using BloodBank.Domain.Enums;
using BloodBank.Domain.Entities;

namespace BloodBank.Domain.Interfaces;

public interface IBloodStorageRepository : IRepository<BloodStorage>
{
    Task<BloodStorage?> GetByBloodTypeAsync(BloodType bloodType, RhFactor rhFactor);
}