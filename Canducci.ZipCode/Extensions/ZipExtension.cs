using Canducci.ZipCode.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace Canducci.ZipCode.Extensions
{
   public static class ZipExtension
   {
      public static IServiceCollection AddZipCode(this IServiceCollection services)
      {         
         services.AddHttpClient<IRequestZipCode, RequestZipCode>();
         return services;
      }
   }
}
