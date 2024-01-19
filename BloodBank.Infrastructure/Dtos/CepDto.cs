using System.Text.Json.Serialization;

namespace BloodBank.Infrastructure.Dtos;

public class CepDto
{
    [JsonPropertyName("cep")]
    public string PostalCode { get; set; }

    [JsonPropertyName("logradouro")]
    public string Street { get; set; }

    [JsonPropertyName("complemento")]
    public string Complemento { get; set; }

    [JsonPropertyName("bairro")]
    public string District { get; set; }

    [JsonPropertyName("localidade")]
    public string Localidade { get; set; }

    [JsonPropertyName("uf")]
    public string State { get; set; }

    [JsonPropertyName("ibge")]
    public string Ibge { get; set; }

    [JsonPropertyName("gia")]
    public string Gia { get; set; }

    [JsonPropertyName("ddd")]
    public string Ddd { get; set; }

    [JsonPropertyName("siafi")]
    public string Siafi { get; set; }
}
