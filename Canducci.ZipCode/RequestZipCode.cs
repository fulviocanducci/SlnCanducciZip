using Canducci.ZipCode.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace Canducci.ZipCode
{
   public class RequestZipCode : IRequestZipCode
   {
      private readonly HttpClient _httpClient;

      public RequestZipCode(HttpClient httpClient)
      {
         _httpClient = httpClient;
         _httpClient.BaseAddress = new Uri("https://viacep.com.br/");
      }

      public async Task<Zip> FindAsync(ZipCodeValue zipCodeValue)
      {
         try
         {
            return await _httpClient.GetFromJsonAsync<Zip>($"ws/{zipCodeValue}/json/");
         }
         catch (Exception)
         {
            throw;
         }
      }
   }
}