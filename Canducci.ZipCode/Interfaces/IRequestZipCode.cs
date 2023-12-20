using System.Threading.Tasks;
namespace Canducci.ZipCode.Interfaces
{
   public interface IRequestZipCode
   {
      Task<Zip> FindAsync(string value);
   }
}
