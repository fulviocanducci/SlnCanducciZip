using System.Net;
namespace Canducci.ZipCode
{
   public class ZipResult
   {
      public ZipResult(HttpStatusCode httpStatusCode, Zip zip)
      {
         HttpStatusCode = httpStatusCode;
         StatusCode = (int)httpStatusCode;
         IsValid = httpStatusCode == HttpStatusCode.OK;
         Zip = zip;
      }
      public HttpStatusCode HttpStatusCode { get; }
      public int StatusCode { get; }
      public bool IsValid { get; }
      public Zip Zip { get; }
   }
}