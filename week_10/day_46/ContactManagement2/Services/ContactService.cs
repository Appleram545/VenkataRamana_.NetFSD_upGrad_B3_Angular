using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement2.Interfaces;
using ContactManagement2.Models;

namespace ContactManagement2.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public List<Contact> GetAll()
        {
            return _repo.GetAll();
        }

        public Contact GetById(int id)
        {
            var contact = _repo.GetById(id);

            if (contact == null)
                throw new KeyNotFoundException("Contact not found");

            return contact;
        }

        public void Add(Contact contact)
        {
            Validate(contact);
            _repo.Add(contact);
        }

        public void Update(int id, Contact contact)
        {
            Validate(contact);

            var existing = _repo.GetById(id);
            if (existing == null)
                throw new KeyNotFoundException("Contact not found");

            contact.Id = id;
            _repo.Update(contact);
        }

        public void Delete(int id)
        {
            var contact = _repo.GetById(id);

            if (contact == null)
                throw new KeyNotFoundException("Contact not found");

            _repo.Delete(contact);
        }

        private static void Validate(Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new ArgumentException("Name is required");

            if (string.IsNullOrWhiteSpace(contact.Email))
                throw new ArgumentException("Email is required");


        }
    }
}