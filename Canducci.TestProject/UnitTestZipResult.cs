using Canducci.ZipCode;

namespace Canducci.TestProject
{
   public class TestsZipResult
   {
      [SetUp]
      public void Setup()
      {
      }

      [Test]
      public void TestZipResultIsNotNull()
      {
         ZipResult zip = new ZipResult(System.Net.HttpStatusCode.OK, new Zip());
         Assert.IsNotNull(zip);
         Assert.IsTrue(zip.HttpStatusCode == System.Net.HttpStatusCode.OK);
         Assert.That(zip.StatusCode, Is.EqualTo(200));
      }
   }
}