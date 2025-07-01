using PhonebookApp.Models;
using PhonebookApp.Repositories;
using PhonebookApp.Services;

namespace PhonebookApp.Utils;

public class RunProgramUtil
{
    public static async Task RunProgram()
    {
        Console.WriteLine("Opening Phonebook App...");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        await UserOptions();
    }

    private static async Task UserOptions()
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
                    await contactService.GetAllContacts();
                    break;
                case "2":
                    Console.WriteLine("View A Contact selected.");
                    await contactService.GetContactById();
                    break;
                case "3":
                    Console.WriteLine("Add A Contact selected.");
                    contactService.AddContact();
                    break;
                case "4":
                    Console.WriteLine("Update A Contact selected.");
                    await contactService.UpdateContactById();
                    break;
                case "5":
                    Console.WriteLine("Delete A Contact selected.");
                    await contactService.DeleteContactById();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}