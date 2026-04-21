using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.Models;

namespace ContactManagement.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        void UpdateContact(int id, Contact updatedContact);
        void DeleteContact(int id);
        List<Contact> GetAllContacts();
    }
}