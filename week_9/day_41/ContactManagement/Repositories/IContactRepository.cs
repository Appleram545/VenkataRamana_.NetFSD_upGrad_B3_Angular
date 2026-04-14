using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
    }
}