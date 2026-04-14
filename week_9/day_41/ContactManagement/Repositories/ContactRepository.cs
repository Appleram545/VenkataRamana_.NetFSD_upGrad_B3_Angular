using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Repositories
{
    public class ContactRepository : IContactRepository
    {

        private static List<Contact> _contacts = new List<Contact>
        {
            new Contact { Id = 1, Name = "John", Email = "john@mail.com" },
            new Contact { Id = 2, Name = "Alice", Email = "alice@mail.com" },
            new Contact { Id = 3, Name = "Bob", Email = "bob@mail.com" }
        };

        public List<Contact> GetAll()
        {
            Console.WriteLine("Fetching from database");
            return _contacts;
        }

        public Contact GetById(int id)
        {
            Console.WriteLine("Fetching single contact ");
            return _contacts.FirstOrDefault(x => x.Id == id);
        }

    }
}