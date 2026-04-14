using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.DAL.Models;
using ContactManagement.DAL.Data;

namespace ContactManagement.DAL.Repository
{
    public interface IContactRepository
    {
        Task<List<ContactInfo>>GetAll();
        Task<ContactInfo>GetById(int id);
        Task Add(ContactInfo contact);
        Task Update(ContactInfo contact);
        Task Delete (int id);
    }
}