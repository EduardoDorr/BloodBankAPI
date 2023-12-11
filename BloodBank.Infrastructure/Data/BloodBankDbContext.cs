using System.Reflection;
using Microsoft.EntityFrameworkCore;

using BloodBank.Domain.Entities;

namespace BloodBank.Infrastructure.Data;

public class BloodBankDbContext : DbContext
{
    public DbSet<Donor> Donors { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<BloodStorage> BloodStorage { get; set; }

    public BloodBankDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}