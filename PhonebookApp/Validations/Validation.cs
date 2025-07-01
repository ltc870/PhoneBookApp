using System.Text.RegularExpressions;
namespace PhonebookApp.Validations;

public static class Validation
{
   public static bool IsValidPhoneNumber(this string phoneNumber)
   {
      var phoneNumberPattern = @"^\d{3}-\d{3}-\d{4}$";
      bool isPhoneNumberValid = Regex.IsMatch(phoneNumber, phoneNumberPattern);
      if (!isPhoneNumberValid)
      {
         return false;
      }
      return true;
   }
   
   public static bool IsValidEmail(this string email)
   {
      var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
      bool isEmailValid = Regex.IsMatch(email, emailPattern);
      if (!isEmailValid)
      {
         return false;
      }
      return true;
   }
}