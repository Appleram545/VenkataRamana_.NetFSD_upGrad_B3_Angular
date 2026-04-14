using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.DAL.Models;
using ContactManagement.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.DAL.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;


        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContactInfo>> GetAll()
        {
            return await _context.Contacts
    .Include(c => c.Company)
    .Include(c => c.Department)
    .ToListAsync();
        }
        public async Task<ContactInfo> GetById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task Add(ContactInfo contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }
        public async Task Update(ContactInfo contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var data = await _context.Contacts.FindAsync(id);
            if (data != null)
            {
                _context.Contacts.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }


}