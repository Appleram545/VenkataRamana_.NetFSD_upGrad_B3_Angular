using Contactmanagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;
using Contactmanagement.Models;
using Dapper;


namespace Contactmanagement.Repositories
{
    public class ContactRepository: IContactRepository
    {
        private readonly DapperContext _context;


        public ContactRepository(DapperContext context)
        {
            _context = context;

        }

        public IEnumerable<ContactInfo> GetAllContacts()
        {
            var query = @"SELECT c.*, comp.CompanyName, d.DepartmentName
                      FROM ContactInfo c
                      JOIN Company comp ON c.CompanyId = comp.CompanyId
                      LEFT JOIN Department d ON c.DepartmentId = d.DepartmentId";


            var connection = _context.CreateConnection();

            return connection.Query<ContactInfo>(query);
        }

        public ContactInfo GetContactById(int id)
        {
            var query = "SELECT * FROM ContactInfo WHERE ContactId=@Id";

            using var connection = _context.CreateConnection();
            return connection.QueryFirstOrDefault<ContactInfo>(query, new { Id = id });
        }

        public void AddContact(ContactInfo contact)
        {
            var query = @"INSERT INTO ContactInfo 
                    (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                    VALUES (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            var connection = _context.CreateConnection();
            connection.Execute(query, contact);
        }
        public void UpdateContact(ContactInfo contact)
        {
            var query = @"UPDATE ContactInfo SET
                      FirstName=@FirstName,
                      LastName=@LastName,
                      EmailId=@EmailId,
                      MobileNo=@MobileNo,
                      Designation=@Designation,
                      CompanyId=@CompanyId,
                      DepartmentId=@DepartmentId
                      WHERE ContactId=@ContactId";

            var connection = _context.CreateConnection();
            connection.Execute(query, contact);
        }
        public void DeleteContact(int id)
        {
            var query = "DELETE FROM ContactInfo WHERE ContactId=@Id";

             var connection = _context.CreateConnection();
            connection.Execute(query, new { Id = id });
        }
        public IEnumerable<Company> GetCompanies()
        {
             var connection = _context.CreateConnection();
            return connection.Query<Company>("SELECT * FROM Company");
        }
        public IEnumerable<Department> GetDepartments()
        {
             var connection = _context.CreateConnection();
            return connection.Query<Department>("SELECT * FROM Department");
        }

    }
}