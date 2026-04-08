using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.Models;

namespace ContactManagement.DataAccess
{
    public interface IContactRepository
    {
         IEnumerable<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);

        ContactInfo AddContact(ContactInfo contact);

         void UpdateContact (int id, ContactInfo contact);
        void DeleteContact(int id);
        

    }
}