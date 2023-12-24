using BloodBank.Domain.Entities;

namespace BloodBank.Domain.Interfaces;

public interface IDonationRepository : IRepository<Donation>
{
    Task<IEnumerable<Donation>> GetReportWithDonorsAsync(int numberOfDays = 30);
}
