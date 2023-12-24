using Refit;

using BloodBank.Infrastructure.Dtos;

namespace BloodBank.Infrastructure.Repositories;

public interface ICepRepository
{
    [Get("/ws/{cep}/json/")]
    Task<CepDto?> GetByCepAsync(string cep);
}