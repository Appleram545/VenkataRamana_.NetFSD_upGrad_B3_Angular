using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using College.Models;

namespace College.Models
{
    public class Student
    {
        public int StudentId{get; set;}

        public string Name{get; set;}

        [ForeignKey("CourseId")]
        public int CourseId{ get; set;}

        public Course Course{get;set;}
        
    }
}