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
        throw new NotImplementedException();
    }

    public void GetContactById()
    {
        throw new NotImplementedException();
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