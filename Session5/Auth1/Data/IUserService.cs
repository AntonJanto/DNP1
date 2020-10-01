using Auth1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth1.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}
