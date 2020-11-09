using DNP_FamilyOverview1.Models.Authentication;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace DNP_FamilyOverview1.Data.Authentication.Impl
{
    public class CloudUserService : IUserService
    {
        private readonly string url = "http://localhost:5002/api/users";

        public async Task RegisterUserAsync(string username, string password)
        {
            HttpClient httpClient = new HttpClient();
            var userAsJson = JsonSerializer.Serialize(new User(username, password));
            await httpClient.PutAsync(url, new StringContent(userAsJson, Encoding.UTF8, "application/json"));
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            HttpClient httpClient = new HttpClient();
            var passwordAsJson = JsonSerializer.Serialize(password);
            var response = await httpClient.PostAsync(url + $"?username={username}", new StringContent(passwordAsJson, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var userAsJson = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<User>(userAsJson);
                return user;
            }
            else
                throw new Exception("Incorrect username or password");
        }
    }
}
