using FamilyAPI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FamilyAPI.Data.Authentication
{
    public class UserService : IUserService
    {
        public IList<User> Users { get; private set; }

        private readonly string usersFile = "Data/FileData/users.json";

        public UserService()
        {
            if (File.Exists(usersFile))
            {
                Users = ReadUsers();
            }
            else
                Users = new List<User>();
        }
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            try
            {
                var u = Users.First(u => u.Username == username && u.Password == password);
                return u;
            }
            catch (Exception)
            {
                throw new Exception("Incorrect username or password");
            }
        }

        public async Task RegisterUserAsync(string username, string password)
        {
            int same = Users.Where(u => u.Username == username).Count();
            if (same == 0)
            {
                var u = new User { Username = username, Password = password };
                Users.Add(u);
                SaveChanges();
            }
            else
                throw new Exception("User with this name already exists");
        }

        private IList<User> ReadUsers()
        {
            using (var jsonText = File.OpenText(usersFile))
            {
                return JsonSerializer.Deserialize<List<User>>(jsonText.ReadToEnd());
            }
        }

        private void SaveChanges()
        {
            string jsonUsers = JsonSerializer.Serialize(Users.ToList(), new JsonSerializerOptions
            {
                WriteIndented = true
            });

            using (StreamWriter outputFile = new StreamWriter(usersFile, false))
            {
                outputFile.Write(jsonUsers);
            }
        }
    }
}
