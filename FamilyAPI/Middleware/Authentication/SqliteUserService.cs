using System;
using System.Threading.Tasks;
using FamilyAPI.DataAccess;
using FamilyAPI.Models.Authentication;
using Microsoft.EntityFrameworkCore;

namespace FamilyAPI.Middleware.Authentication
{
    public class SqliteUserService : IUserService
    {
        private readonly FamilyApiContext _familyApiContext;

        public SqliteUserService(FamilyApiContext familyApiContext)
        {
            _familyApiContext = familyApiContext;
        }

        public async Task<User> ValidateUserAsync(string usermame, string password)
        {
            var user = await _familyApiContext.Users.FindAsync(usermame);
            
            return user?.Password == password ? 
                user : 
                throw new Exception("Incorrect username or password");
        }

        public async Task RegisterUserAsync(string username, string password)
        {
            var user = await _familyApiContext.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                var newUser = new User
                {
                    Username = username,
                    Password = password
                };
                await _familyApiContext.Users.AddAsync(newUser);
                await _familyApiContext.SaveChangesAsync();
            }
        }
    }
}