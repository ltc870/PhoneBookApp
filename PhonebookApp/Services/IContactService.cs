namespace PhonebookApp.Services;

public interface IContactService
{
    public void GetAllContacts();
    public void GetContactById();
    public void AddContact();
    public void UpdateContactById();
    public void DeleteContactById();
}