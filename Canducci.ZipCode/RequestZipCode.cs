using Canducci.ZipCode.Interfaces;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
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

      public async Task<ZipResult> FindAsync(ZipCodeValue zipCodeValue)
      {
         try
         {
            HttpResponseMessage httpResponseMessage = await _httpClient
               .GetAsync($"ws/{zipCodeValue.Value}/json/");

            Stream json = await httpResponseMessage
               .Content
               .ReadAsStreamAsync();

            return new ZipResult
               (
                  httpResponseMessage.StatusCode,
                  await JsonSerializer.DeserializeAsync<Zip>(json)
               );
         }
         catch (Exception)
         {
            throw;
         }
      }
   }
}