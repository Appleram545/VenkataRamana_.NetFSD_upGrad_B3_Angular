using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using College.Models;

namespace College.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName{get;set;}


        public List<Student>Students{get;set;}    // Navigation 
    }
}