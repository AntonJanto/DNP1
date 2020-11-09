using DNP_FamilyOverview1.Models.Families;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DNP_FamilyOverview1.Data.Families
{
    public class CloudFamilyService : IFamilyService
    {
        private readonly string url = "http://localhost:5002/api";
        private readonly HttpClient client = new HttpClient();

        public async Task<bool> AddFamilyAsync(Family toAdd)
        {
            var fam = JsonSerializer.Serialize(toAdd);
            StringContent familyAsJson = new StringContent(fam, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url + "/families", familyAsJson);
            if (response.IsSuccessStatusCode)
                return true;
            else if (response.StatusCode == HttpStatusCode.BadRequest)
                throw new Exception("Family already exists");
            else
                throw new Exception("Family could not be created");
        }

        public async Task<IList<Family>> GetFamiliesAsync()
        {
            string response = await client.GetStringAsync(url + "/families");
            IList<Family> result = JsonSerializer.Deserialize<IList<Family>>(response);
            return result;
        }

        public async Task<bool> RemoveAdultAsync(Adult toRemove)
        {
            var response = await client.DeleteAsync(url + $"/adults/{toRemove.Id}");
            return response.IsSuccessStatusCode;

        }

        public async Task<bool> RemoveFamilyAsync(Family toRemove)
        {
            string streetName = toRemove.StreetName.Replace(" ", "-");
            int houseNumber = toRemove.HouseNumber;
            var response = await client.DeleteAsync(url + $"/families?streetname={streetName}&housenumber={houseNumber}");
            return response.IsSuccessStatusCode;
        }

        private IList<Adult> CollectAdults(IList<Family> families)
        {
            IList<Adult> adults = new List<Adult>();
            foreach (var family in families)
            {
                foreach (var adult in family.Adults)
                {
                    adults.Add(adult);
                }
            }
            return adults;
        }
    }
}
