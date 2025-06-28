using PhonebookApp.Models;

namespace PhonebookApp.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ContactContext _context;
    
public ContactRepository(ContactContext context)
    {
        _context = context;
    }
    public List<Contact> GetAllContacts()
    {
        throw new NotImplementedException();
    }

    public Contact GetContactById(int id)
    {
        throw new NotImplementedException();
    }

    public void AddContact(Contact contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        Console.WriteLine("Contact added successfully!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void UpdateContactById(int id)
    {
        throw new NotImplementedException();
    }

    public void DeleteContactById(int id)
    {
        throw new NotImplementedException();
    }
}