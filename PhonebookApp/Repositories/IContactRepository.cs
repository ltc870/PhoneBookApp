using PhonebookApp.Models;

namespace PhonebookApp.Repositories;

public interface IContactRepository
{
    public Task<List<Contact>> GetAllContacts();
    public Task<Contact> GetContactById(int id);
    public Task AddContact(Contact contact);
    public Task UpdateContactById(int id, Contact updatedContact);
    public Task DeleteContactById(int id);
    
}