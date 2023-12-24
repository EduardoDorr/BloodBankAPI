using Microsoft.EntityFrameworkCore;

using BloodBank.Domain.Entities;
using BloodBank.Domain.Interfaces;
using BloodBank.Infrastructure.Data;

namespace BloodBank.Infrastructure.Repositories;

public class DonationRepository : IDonationRepository
{
    private readonly BloodBankDbContext _context;

    public DonationRepository(BloodBankDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Donation>> GetAllAsync(int skip = 0, int take = 50)
    {
        return await _context.Donations.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Donation?> GetByIdAsync(int id)
    {
        return await _context.Donations.SingleOrDefaultAsync(d => d.Id == id);
    }

    public async Task<IEnumerable<Donation>> GetReportWithDonorsAsync(int numberOfDays = 30)
    {
        return await _context.Donations.Include(d => d.Donor)
                                       .Where(d => d.DonationDate >= DateTime.Now.AddDays(-numberOfDays))
                                       .OrderByDescending(d => d.DonationDate)
                                       .ToListAsync();
    }

    public void Create(Donation donation)
    {
        _context.Donations.Add(donation);
    }

    public void Update(Donation donation)
    {
        _context.Donations.Update(donation);
    }    

    public void Delete(Donation donation)
    {
        _context.Donations.Remove(donation);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
