using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ContactService.DTOs
{
    public class ContactDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CategoryId { get; set; }
    }
}
