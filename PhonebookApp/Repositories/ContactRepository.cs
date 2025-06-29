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
    public async Task<List<Contact>> GetAllContacts()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task<Contact> GetContactById(int id)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(contact => contact.Id == id);
        if (contact == null)
        {
            throw new KeyNotFoundException($"Contact with ID {id} not found.");
        }
        return contact;
    }

    public async Task AddContact(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();
        Console.WriteLine("Contact added successfully!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public async Task UpdateContactById(int id, Contact updatedContact)
    {
        var existingContact = await _context.Contacts.FirstOrDefaultAsync(contact => contact.Id == id);
        if (existingContact != null)
        {
            existingContact.Name = updatedContact.Name;
            existingContact.PhoneNumber = updatedContact.PhoneNumber;
            existingContact.Email = updatedContact.Email;
            await _context.SaveChangesAsync();
            Console.WriteLine("Contact updated successfully!");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public async Task DeleteContactById(int id)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(contact => contact.Id == id);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
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