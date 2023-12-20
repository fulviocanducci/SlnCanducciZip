using System;
using System.Text.RegularExpressions;
namespace Canducci.ZipCode
{
   public partial class ZipCodeValue
   {

      private static Regex RegexZip = new Regex("^\\d{8}$");
      private static Regex RegexOnlyNumber = new Regex("[^\\d]");

      public string Value { get; private set; }

      public ZipCodeValue(string value)
      {
         value = string.Join("", RegexOnlyNumber.Split(value));
         if (!string.IsNullOrEmpty(value) || !RegexZip.IsMatch(value))
         {
            throw new Exception("Zip value is invalid");
         }
         Value = value;
      }

      public static bool TryParse(string value, out ZipCodeValue zipCodeValue)
      {
         value = string.Join("", RegexOnlyNumber.Split(value));
         if (value == null || !RegexZip.IsMatch(value))
         {
            zipCodeValue = null;
            return false;
         }
         zipCodeValue = value;
         return true;
      }

      public static implicit operator string(ZipCodeValue zipCodeValue)
      {
         return zipCodeValue.Value;
      }

      public static implicit operator ZipCodeValue(string value)
      {
         return new ZipCodeValue(value);
      }
   }
}

