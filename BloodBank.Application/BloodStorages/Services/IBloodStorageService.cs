using BloodBank.Domain.Entities;
using BloodBank.Domain.ValueObjects;

namespace BloodBank.Application.BloodStorages.Services;

public interface IBloodStorageService
{
    Task AddAmount(BloodData bloodData, int amountInML);
    Task WithdrawAmount(BloodData bloodData, int amountInML);
}