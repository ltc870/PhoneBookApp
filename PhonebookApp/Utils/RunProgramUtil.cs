using PhonebookApp.Models;
using PhonebookApp.Repositories;
using PhonebookApp.Services;

namespace PhonebookApp.Utils;

public class RunProgramUtil
{
    public static void RunProgram()
    {
        Console.WriteLine("Opening Phonebook App...");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        UserOptions();
    }

    private static void UserOptions()
    {
        ContactService contactService = new ContactService(new ContactRepository(new ContactContext()));
        bool phonebookAppRunning = true;

        while (phonebookAppRunning)
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("<---------------------------------------------------------->\n");
            Console.WriteLine("Type 0 to Close Program.");
            Console.WriteLine("Type 1 View All Contacts");
            Console.WriteLine("Type 2 View A Contact");
            Console.WriteLine("Type 3 Add A Contact");
            Console.WriteLine("Type 4 Update A Contact");
            Console.WriteLine("Type 5 Delete A Contact");
            Console.WriteLine("\n<---------------------------------------------------------->");
            
            string userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case "0":
                    Console.Clear();
                    phonebookAppRunning = false;
                    Console.WriteLine("Closing Phonebook App...");
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case "1":
                    Console.WriteLine("View All Contacts selected.");
                    contactService.GetAllContacts();
                    break;
                case "2":
                    Console.WriteLine("View A Contact selected.");
                    contactService.GetContactById();
                    break;
                case "3":
                    Console.WriteLine("Add A Contact selected.");
                    contactService.AddContact();
                    break;
                case "4":
                    Console.WriteLine("Update A Contact selected.");
                    // Call method to update an existing contact
                    break;
                case "5":
                    Console.WriteLine("Delete A Contact selected.");
                    // Call method to delete a contact
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}