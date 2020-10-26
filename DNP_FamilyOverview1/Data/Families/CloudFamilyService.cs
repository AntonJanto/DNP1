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
        private readonly string url = "http://dnp.metamate.me";
        private readonly HttpClient client = new HttpClient();


        public async Task<bool> AddAdultToFamilyAsync(Adult adultToAdd, Family familyToJoin)
        {
            IList<Family> families = await GetFamiliesAsync();
            IList<Adult> adults = CollectAdults(families);
            Family family;

            try
            {
                family = families.First(f => f.StreetName == familyToJoin.StreetName && f.HouseNumber == familyToJoin.HouseNumber);
            }
            catch (ArgumentNullException)
            {
                return false;
            }

            if (family.Adults.Count < 2)
            {
                int maxId = adults.Any() ? adults.Max(a => a.Id) : 0;

                if (adults.Any(a => a.Equals(adultToAdd)))
                    throw new Exception($"{adultToAdd.FirstName} {adultToAdd.LastName} cannot lead a double life.");

                adultToAdd.Id = ++maxId;
                family.Adults.Add(adultToAdd);
                StringContent familyAsJson = new StringContent(JsonSerializer.Serialize(family), Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url + "/families", familyAsJson);
                return response.IsSuccessStatusCode;
            }
            else
            {
                throw new Exception("Family already has 2 adults.");
            }
        }

        public async Task<bool> AddFamilyAsync(Family toAdd)
        {
            IList<Family> families = await GetFamiliesAsync();
            var fam = JsonSerializer.Serialize(toAdd);
            StringContent familyAsJson = new StringContent(fam, Encoding.UTF8, "application/json");

            int same = families.Where(f =>
                (f.HouseNumber == toAdd.HouseNumber && f.StreetName == toAdd.StreetName)).Count();

            if (same < 1)
            {
                var response = await client.PutAsync(url + "/families", familyAsJson);
                return response.IsSuccessStatusCode;
            }
            else
                throw new Exception("This family already exists");
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
