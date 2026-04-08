using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }

        public string Name { get; set; } 

        public string Email { get; set; } 

        public string Phone { get; set; } 

        public Company Company { get; set; }

        public Department Department { get; set; }
    }
}