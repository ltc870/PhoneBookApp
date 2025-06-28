using PhonebookApp.Models;

namespace PhonebookApp.Repositories;

public interface IContactRepository
{
    public List<Contact> GetAllContacts();
    public Contact GetContactById(int id);
    public void AddContact(Contact contact);
    public void UpdateContactById(int id);
    public void DeleteContactById(int id);
    
}