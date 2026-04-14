using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Services
{
    public interface IContactService
    {

        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
    }
}