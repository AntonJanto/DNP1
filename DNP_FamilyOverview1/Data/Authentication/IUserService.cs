using DNP_FamilyOverview1.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNP_FamilyOverview1.Data.Authentication
{
    public interface IUserService
    {
        User ValidateUser(string usermame, string password);
        void RegisterUser(string username, string password);
    }
}
