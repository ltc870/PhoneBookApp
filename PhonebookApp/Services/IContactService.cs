namespace PhonebookApp.Services;

public interface IContactService
{
    public Task GetAllContacts();
    public Task GetContactById();
    public Task AddContact();
    public Task UpdateContactById();
    public Task DeleteContactById();
}