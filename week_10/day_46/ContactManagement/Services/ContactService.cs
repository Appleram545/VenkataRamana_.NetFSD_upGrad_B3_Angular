using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.Interfaces;
using ContactManagement.Models;
using ContactManagement.Utils;


namespace ContactManagement.Services
{
    public class ContactService
    {
        private readonly List<Contact> _contacts = new();

        public void AddContact(Contact contact)
        {
            Validator.ValidateContact(contact);

            _contacts.Add(contact);
        }

        public void UpdateContact(int id, Contact updatedContact)
        {
            Validator.ValidateContact(updatedContact);

            var existing = _contacts.FirstOrDefault(c => c.Id == id);

            if (existing == null)
                throw new KeyNotFoundException("Contact not found");

            existing.Name = updatedContact.Name;
            existing.Email = updatedContact.Email;
            existing.Phone = updatedContact.Phone;
        }

        public void DeleteContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
                throw new KeyNotFoundException("Contact not found");

            _contacts.Remove(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts.ToList();
        }
    }
}