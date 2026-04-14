using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}