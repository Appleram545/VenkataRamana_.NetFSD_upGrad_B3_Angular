using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.DataAccess;
using ContactManagement.Models;

namespace ContactManagement.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo{ContactId = 1,
        Name = "ram",
        Email = "ram@gmail.com",
        Phone = "9879378299",
        Company = new Company
        {
            CompanyId = 1,
            CompanyName = "CTS"
        },
        Department = new Department
        {
            DepartmentId = 1,
            DepartmentName = "IT"
        }
            },
            new ContactInfo
    {
        ContactId = 3,
        Name = "sadvika",
        Email = "sadvika@gmail.com",
        Phone = "9768382378",
        Company = new Company
        {
            CompanyId = 3,
            CompanyName = "Wipro"
        },
        Department = new Department
        {
            DepartmentId = 3,
            DepartmentName = "HR"
        }
    }
    };

        public IEnumerable<ContactInfo> GetAllContacts()
        {
            return contacts;
        }
        public ContactInfo GetContactById(int id)
        {
            return contacts.FirstOrDefault(x=>x.ContactId==id);

        }

        public ContactInfo AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
            return contact;
        }
        public void UpdateContact(int id,ContactInfo contact)
        {
            var existing = contacts.FirstOrDefault(x=>x.ContactId == id);

            if(existing != null)
            {
                existing.Name = contact.Name;
                existing.Email = contact.Email;
                existing.Phone = contact.Phone;
                existing.Company = contact.Company;
                existing.Department = contact.Department;

            }
        }
        public void DeleteContact(int id)
        {
            var del = contacts.FirstOrDefault(x=>x.ContactId==id);


            if(del != null)
            {
                contacts.Remove(del);
            }
        }



    }

}