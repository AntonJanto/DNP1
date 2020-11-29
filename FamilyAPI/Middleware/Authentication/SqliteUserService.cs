using System;
using System.Security.Cryptography;
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
            var savedUser = await _familyApiContext.Users.FindAsync(usermame);

            if (savedUser == null) throw new Exception("Incorrect username or password");
            var isValidUser = ValidatePassword(password, savedUser.Password);
            if (isValidUser)
            {
                return savedUser;
            }
            throw new Exception("Incorrect username or password");
        }

        private static bool ValidatePassword(string password, string savedPw)
        {
            byte[] hashBytes = Convert.FromBase64String(savedPw);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 15000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
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
                    Password = HashAndSalt(password)
                };
                await _familyApiContext.Users.AddAsync(newUser);
                await _familyApiContext.SaveChangesAsync();
            }
        }

        private string HashAndSalt(string pw)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(pw, salt, 15000);
            var hash = pbkdf2.GetBytes(20);

            var hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPwHash = Convert.ToBase64String(hashBytes);
            return savedPwHash;
        }
    }
}