using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactService.Models;
using ContactService.DTOs;
using ContactService.Repositories;

namespace ContactService.Services
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
            return _repo.GetById(id);
        }

        public void Add(ContactDto dto)
        {
            var contact = new Contact
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                CategoryId = dto.CategoryId
            };
            _repo.Add(contact);
        }
        public void Update(int id, ContactDto dto)
        {
            var contact = _repo.GetById(id);
            if (contact == null) return;

            contact.Name = dto.Name;
            contact.Email = dto.Email;
            contact.Phone = dto.Phone;
            contact.CategoryId = dto.CategoryId;

            _repo.Update(contact);
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}