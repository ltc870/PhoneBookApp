using PhonebookApp.Models;
using PhonebookApp.Repositories;
using PhonebookApp.Validations;

namespace PhonebookApp.Services;

public class ContactService : IContactService
{
    
    private readonly IContactRepository _contactRepository;
    
public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    
    public async Task GetAllContacts()
    {
        Console.Clear();
        List<Contact> contacts = await _contactRepository.GetAllContacts();
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
            Console.WriteLine("\n<---------------------------------------------------------->");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public async Task GetContactById()
    {
        Console.Clear();
        await GetAllContacts();
        Console.WriteLine("Please enter the contact ID you want to view:");
        string id = Console.ReadLine() ?? string.Empty;
        Contact contact = await _contactRepository.GetContactById(int.Parse(id));
        
        Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public async Task AddContact()
    {
        Console.Clear();
        Console.WriteLine("Adding a new contact...");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.WriteLine("Please enter the contact's name:");
        string contactName = Console.ReadLine() ?? string.Empty;
        
        do {
            if (string.IsNullOrWhiteSpace(contactName))
            {
                Console.WriteLine("Name cannot be empty. Please enter a valid name:");
                contactName = Console.ReadLine() ?? string.Empty;
            }
        } while (string.IsNullOrWhiteSpace(contactName));
        
        Console.WriteLine("Please enter the contact's phone number:");
        string contactPhoneNumber = Console.ReadLine() ?? string.Empty;
        
        do {
            if (string.IsNullOrWhiteSpace(contactPhoneNumber))
            {
                Console.WriteLine("Phone number cannot be empty. Please enter a valid phone number:");
                contactPhoneNumber = Console.ReadLine() ?? string.Empty;
            }
        } while (string.IsNullOrWhiteSpace(contactPhoneNumber));
        
        bool isPhoneNumberValid = contactPhoneNumber.IsValidPhoneNumber();
        do {
            if (!isPhoneNumberValid)
            {
                Console.WriteLine("Invalid phone number format. Please enter a valid phone number:");
                contactPhoneNumber = Console.ReadLine() ?? string.Empty;
                isPhoneNumberValid = contactPhoneNumber.IsValidPhoneNumber();
            }
        } while (!isPhoneNumberValid);
        
        Console.WriteLine("Please enter the contact's email:");
        string contactEmail = Console.ReadLine() ?? string.Empty;
        
        do {
            if (string.IsNullOrWhiteSpace(contactEmail))
            {
                Console.WriteLine("Email cannot be empty. Please enter a valid email:");
                contactEmail = Console.ReadLine() ?? string.Empty;
            }
        } while (string.IsNullOrWhiteSpace(contactEmail));
        
        contactEmail.IsValidEmail();
        do {
            if (!contactEmail.IsValidEmail())
            {
                Console.WriteLine("Invalid email format. Please enter a valid email:");
                contactEmail = Console.ReadLine() ?? string.Empty;
            }
        } while (!contactEmail.IsValidEmail());
        
        Contact newContact = new Contact
        {
            Name = contactName,
            PhoneNumber = contactPhoneNumber,
            Email = contactEmail
        };
        
        await _contactRepository.AddContact(newContact);
    }

    public async Task UpdateContactById()
    {
        Console.Clear();
        Console.WriteLine("Updating a contact...");
        await GetAllContacts();
        Console.WriteLine("Please enter the contact ID you want to update:");
        string id = Console.ReadLine() ?? string.Empty;
        Contact contact = await _contactRepository.GetContactById(int.Parse(id));
        Console.WriteLine("Current Contact Details:");
        Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
        Console.WriteLine("Please enter the new name (or press Enter to keep current):");
        string newName = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Please enter the new phone number (or press Enter to keep current):");
        string newPhoneNumber = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Please enter the new email (or press Enter to keep current):");
        string newEmail = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrEmpty(newName)) contact.Name = newName;
        if (!string.IsNullOrEmpty(newPhoneNumber)) contact.PhoneNumber = newPhoneNumber;
        if (!string.IsNullOrEmpty(newEmail)) contact.Email = newEmail;
        await _contactRepository.UpdateContactById(contact.Id, contact);
    }

    public async Task DeleteContactById()
    {
        Console.Clear();
        Console.WriteLine("Deleting a contact...");
        await GetAllContacts();
        Console.WriteLine("Please enter the contact ID you want to delete:");
        string id = Console.ReadLine() ?? string.Empty;
        
        await _contactRepository.DeleteContactById(int.Parse(id));
    }
}