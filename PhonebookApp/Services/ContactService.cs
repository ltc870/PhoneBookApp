using PhonebookApp.Models;
using PhonebookApp.Repositories;

namespace PhonebookApp.Services;

public class ContactService : IContactService
{
    
    private readonly IContactRepository _contactRepository;
    
public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    
    public void GetAllContacts()
    {
        Console.Clear();
        List<Contact> contacts = _contactRepository.GetAllContacts();
        Console.WriteLine("Fetching all contacts...");
        Console.WriteLine("<---------------------------------------------------------->\n");
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found.");
        }
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }
        Console.WriteLine("\n<---------------------------------------------------------->");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void GetContactById()
    {
        Console.Clear();
        GetAllContacts();
        Console.WriteLine("Please enter the contact ID you want to view:");
        string id = Console.ReadLine() ?? string.Empty;
        Contact contact = _contactRepository.GetContactById(int.Parse(id));
        
        Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void AddContact()
    {
        Console.Clear();
        Console.WriteLine("Adding a new contact...");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.WriteLine("Please enter the contact's name:");
        string contactName = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Please enter the contact's phone number:");
        string contactPhoneNumber = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Please enter the contact's email:");
        string contactEmail = Console.ReadLine() ?? string.Empty;
        
        Contact newContact = new Contact
        {
            Name = contactName,
            PhoneNumber = contactPhoneNumber,
            Email = contactEmail
        };
        
        _contactRepository.AddContact(newContact);
    }

    public void UpdateContactById()
    {
        throw new NotImplementedException();
    }

    public void DeleteContactById()
    {
        throw new NotImplementedException();
    }
}