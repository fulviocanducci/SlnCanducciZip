using Canducci.ZipCode.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Canducci.ZipCode
{
   public class RequestZipCode : IRequestZipCode
   {
      private readonly HttpClient _httpClient;
      private Regex _regexZip;

      public RequestZipCode(HttpClient httpClient)
      {
         _httpClient = httpClient;
         _httpClient.BaseAddress = new Uri("https://viacep.com.br/");
         _regexZip = new Regex(@"^\d{8}$");
      }

      public async Task<Zip> FindAsync(string value)
      {
         try
         {
            if (value.Length == 8 || value.Length == 9 || value.Length == 10)
            {
               value = value.Replace(".", "").Replace("-", "");
               if (!_regexZip.IsMatch(value))
               {
                  throw new Exception("Zip value is invalid");
               }
            }
            return await _httpClient.GetFromJsonAsync<Zip>($"ws/{value}/json/");
         }
         catch (Exception)
         {
            throw;
         }
      }
   }
}
