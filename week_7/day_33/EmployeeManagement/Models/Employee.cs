using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        
        public int EmployeeId{get; set;}
        public string Ename{get; set;}
        public string Job{get; set;}
        public double Salary{get; set;}

        [ForeignKey("DeptId")]
        public int DeptId{get; set;}


    public Dept Dept { get; set;}
    }
}