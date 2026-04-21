using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement2.Models;

namespace ContactManagement2.Interfaces
{
    public interface IContactService
    {
        List<Contact> GetAll();

        Contact GetById(int id);

        void Add(Contact contact);

        void Update(int id, Contact contact);

        void Delete(int id);
    }
}