using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement2.Interfaces;
using ContactManagement2.Models;

namespace ContactManagement2.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new();

        public List<Contact> GetAll() => _contacts;

        public Contact? GetById(int id)
            => _contacts.FirstOrDefault(c => c.Id == id);

        public void Add(Contact contact)
            => _contacts.Add(contact);

        public void Update(Contact contact)
        {
            var existing = GetById(contact.Id);
            if (existing == null) return;

            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
        }

        public void Delete(Contact contact)
            => _contacts.Remove(contact);
    }
}