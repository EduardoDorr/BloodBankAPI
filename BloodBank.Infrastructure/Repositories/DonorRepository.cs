using Microsoft.EntityFrameworkCore;

using BloodBank.Domain.Entities;
using BloodBank.Domain.Interfaces;
using BloodBank.Infrastructure.Data;

namespace BloodBank.Infrastructure.Repositories;

public class DonorRepository : IDonorRepository
{
    private readonly BloodBankDbContext _context;

    public DonorRepository(BloodBankDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Donor>> GetAllAsync(int skip = 0, int take = 50)
    {
        return await _context.Donors.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Donor?> GetByIdAsync(int id)
    {
        return await _context.Donors.SingleOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Donor?> GetWithDonationsByIdAsync(int id, int take = 50)
    {
        return await _context.Donors.Include(d => d.Donations.OrderByDescending(d => d.DonationDate).Take(take))
                                    .SingleOrDefaultAsync(d => d.Id == id);
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        return await _context.Donors.AnyAsync(d => d.Email.Address == email);
    }

    public void Create(Donor donor)
    {
        _context.Donors.Add(donor);
    }

    public void Update(Donor donor)
    {
        _context.Donors.Update(donor);
    }

    public void Delete(Donor donor)
    {
        _context.Donors.Remove(donor);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }   
}