using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginPageViaRepositoryPattern.Models
{
    public class Users
    {
        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmpass { get; set; }
    }
}
