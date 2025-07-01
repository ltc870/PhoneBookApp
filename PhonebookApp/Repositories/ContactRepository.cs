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
        try
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            Console.WriteLine("Contact added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding contact: {ex.Message}");
            
        }
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
            try
            {
                await _context.SaveChangesAsync();
                Console.WriteLine("Contact updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating contact: {ex.Message}");
                throw;
            }
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
            try
            {
                await _context.SaveChangesAsync();
                Console.WriteLine("Contact deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting contact: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}