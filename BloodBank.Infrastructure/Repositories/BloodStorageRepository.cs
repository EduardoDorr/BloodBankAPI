using Microsoft.EntityFrameworkCore;

using BloodBank.Domain.Entities;
using BloodBank.Domain.Interfaces;
using BloodBank.Infrastructure.Data;
using BloodBank.Domain.ValueObjects;

namespace BloodBank.Infrastructure.Repositories;

public class BloodStorageRepository : IBloodStorageRepository
{
    private readonly BloodBankDbContext _context;

    public BloodStorageRepository(BloodBankDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BloodStorage>> GetAllAsync(int skip = 0, int take = 50)
    {
        return await _context.BloodStorage.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<BloodStorage?> GetByIdAsync(int id)
    {
        return await _context.BloodStorage.SingleOrDefaultAsync(b => b.Id == id);
    }

    public async Task<BloodStorage?> GetByBloodTypeAsync(BloodType bloodType, RhFactor rhFactor)
    {
        return await _context.BloodStorage.SingleOrDefaultAsync(b => b.BloodData.BloodType == bloodType &&
                                                                     b.BloodData.RhFactor == rhFactor);
    }

    public void Create(BloodStorage bloodStorage)
    {
        _context.BloodStorage.Add(bloodStorage);
    }

    public void Update(BloodStorage bloodStorage)
    {
        _context.BloodStorage.Update(bloodStorage);
    }

    public void Delete(BloodStorage bloodStorage)
    {
        _context.BloodStorage.Remove(bloodStorage);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
