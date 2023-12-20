using System.Text.Json.Serialization;
namespace Canducci.ZipCode
{
   public class Zip
   {
      [JsonPropertyName("cep")]
      public string ZipCode { get; set; } = string.Empty;

      [JsonPropertyName("logradouro")]
      public string Address { get; set; } = string.Empty;

      [JsonPropertyName("complemento")]
      public string Complement { get; set; } = string.Empty;

      [JsonPropertyName("bairro")]
      public string District { get; set; } = string.Empty;

      [JsonPropertyName("localidade")]
      public string City { get; set; } = string.Empty;

      [JsonPropertyName("uf")]
      public string Uf { get; set; } = string.Empty;

      [JsonPropertyName("ibge")]
      public string Ibge { get; set; } = string.Empty;

      [JsonPropertyName("gia")]
      public string Gia { get; set; } = string.Empty;

      [JsonPropertyName("ddd")]
      public string Ddd { get; set; } = string.Empty;

      [JsonPropertyName("siafi")]
      public string Siafi { get; set; } = string.Empty;
   }


}
