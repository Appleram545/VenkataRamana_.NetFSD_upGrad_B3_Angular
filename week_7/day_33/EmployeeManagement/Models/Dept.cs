using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Dept
    {
        public int DeptId { get; set; }

        public string Dname { get; set; }
        public string Location { get; set; }

        public ICollection<Employee> Employees{ get; set; }
    }
}