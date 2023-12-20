using System.Threading.Tasks;
namespace Canducci.ZipCode.Interfaces
{
   public interface IRequestZipCode
   {
      Task<ZipResult> FindAsync(ZipCodeValue zipCodeValue);
   }
}
