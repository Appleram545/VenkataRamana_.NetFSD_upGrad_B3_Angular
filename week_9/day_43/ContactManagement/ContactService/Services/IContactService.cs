using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactService.Models;
using ContactService.DTOs;

namespace ContactService.Services
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        void Add(ContactDto dto);
        void Update(int id, ContactDto dto);
        void Delete(int id);
    }
}