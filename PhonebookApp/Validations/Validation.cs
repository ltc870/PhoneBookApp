using System.Text.RegularExpressions;
namespace PhonebookApp.Validations;

public static class Validation
{
   public static bool IsValidPhoneNumber(this string phoneNumber)
   {
      var phoneNumberPattern = @"^\+?[1-9]\d{1,14}$";
      bool isPhoneNumberValid = Regex.IsMatch(phoneNumber, phoneNumberPattern);
      if (!isPhoneNumberValid)
      {
         Console.WriteLine("Invalid phone number format.");
         Console.WriteLine("Press any key to continue...");
         Console.ReadKey();
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
         Console.WriteLine("Invalid email format.");
         Console.WriteLine("Press any key to continue...");
         Console.ReadKey();
         return false;
      }
      return true;
   }
}