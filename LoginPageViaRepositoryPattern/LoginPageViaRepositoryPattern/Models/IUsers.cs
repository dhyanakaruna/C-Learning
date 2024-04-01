using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginPageViaRepositoryPattern.Models
{
    interface IUsers
    {
        bool Verify(string email, string password);

        bool Register(Users u);

        bool FindDuplicate(string email);
    }
}
