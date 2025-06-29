using Microsoft.EntityFrameworkCore;
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
        return _context.Contacts.ToList();
    }

    public Contact GetContactById(int id)
    {
        var contact = _context.Contacts.FirstOrDefault(contact => contact.Id == id);
        if (contact == null)
        {
            throw new KeyNotFoundException($"Contact with ID {id} not found.");
        }
        return contact;
    }

    public void AddContact(Contact contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        Console.WriteLine("Contact added successfully!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void UpdateContactById(int id, Contact updatedContact)
    {
        var existingContact = _context.Contacts.FirstOrDefault(contact => contact.Id == id);
        if (existingContact != null)
        {
            existingContact.Name = updatedContact.Name;
            existingContact.PhoneNumber = updatedContact.PhoneNumber;
            existingContact.Email = updatedContact.Email;
            _context.SaveChanges();
            Console.WriteLine("Contact updated successfully!");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void DeleteContactById(int id)
    {
        var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            Console.WriteLine("Contact deleted successfully!");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}