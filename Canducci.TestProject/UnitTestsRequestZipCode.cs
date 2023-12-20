using Canducci.ZipCode;
using Canducci.ZipCode.Interfaces;

namespace Canducci.TestProject
{
   public class UnitTestsRequestZipCode
   {
      [SetUp]
      public void Setup()
      {
      }

      [Test]
      public void TestRequestZipCode()
      {
         IRequestZipCode requestZipCode = new RequestZipCode(new HttpClient());
         ZipResult zipResult = requestZipCode.FindAsync("01001000").Result;
         Assert.IsTrue(zipResult.IsValid);
         Assert.IsTrue(zipResult.StatusCode == 200);
         Assert.That(zipResult.HttpStatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
      }
   }
}