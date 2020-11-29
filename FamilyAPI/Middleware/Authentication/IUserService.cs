using FamilyAPI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyAPI.Middleware.Authentication
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string usermame, string password);
        Task RegisterUserAsync(string username, string password);
    }
}
