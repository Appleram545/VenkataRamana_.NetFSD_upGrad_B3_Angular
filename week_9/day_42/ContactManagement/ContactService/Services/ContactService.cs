using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactService.Models;
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

        public List<Contact>GetAll() => _repo.GetAll();

        public Contact GetById(int id) => _repo.GetById(id);

        public void Add(Contact contact) => _repo.Add(contact);

        public void Update(Contact contact) => _repo.Update(contact);

        public void Delete(int id) => _repo.Delete(id);
    }
}