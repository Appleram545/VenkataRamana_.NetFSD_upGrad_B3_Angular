using ContactManagement.Models;


namespace ContactManagement.Services
{
    
    public interface IContactService
    {
        List<ContactInfo> GetAllContacts();

        ContactInfo GetContactById(int id);

        void AddContact(ContactInfo contact);
    }
}