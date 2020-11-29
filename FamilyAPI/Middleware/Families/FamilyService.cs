using FamilyAPI.Data.FileData;
using FamilyAPI.Models.Families;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyAPI.Data.Families
{
    public class FamilyService : IFamilyService
    {
        private readonly FileContext familyFileHandler;

        public FamilyService()
        {
            familyFileHandler = new FileContext();
        }


        public async Task<IList<Family>> GetFamiliesAsync()
        {
            return familyFileHandler.Families;
        }

        public async Task<bool> RemoveFamilyAsync(Family toRemove)
        {
            Family fam = familyFileHandler.Families.FirstOrDefault(f => f.HouseNumber == toRemove.HouseNumber && f.StreetName == toRemove.StreetName);
            bool removed = familyFileHandler.Families.Remove(fam);
            if (removed)
            {
                familyFileHandler.SaveChanges();
            }
            return removed;
        }
        public async Task<Family> AddFamilyAsync(Family toAdd)
        {
            IList<Family> families = familyFileHandler.Families;

            int same = families.Count(f => (f.HouseNumber == toAdd.HouseNumber && f.StreetName == toAdd.StreetName));

            if (same < 1)
            {
                AssignIdsToAdults(toAdd.Adults);
                families.Add(toAdd);
                familyFileHandler.SaveChanges();
                return toAdd;
            }
            else
                throw new Exception("This family already exists");
        }

        public async Task<bool> RemoveAdultAsync(int toRemoveId)
        {
            IList<Family> families = familyFileHandler.Families;
            foreach (var family in families)
            {
                foreach (var adult in family.Adults)
                {
                    if (adult.Id == toRemoveId)
                    {
                        var removed = family.Adults.Remove(adult);
                        familyFileHandler.SaveChanges();
                        return removed;
                    }
                }
            }
            return false;
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

        private void AssignIdsToAdults(IList<Adult> adults)
        {
            IList<Family> families = familyFileHandler.Families;
            int maxId = CollectAdults(families).Max(a => a.Id);

            foreach (var adult in adults)
            {
                adult.Id = ++maxId;
            }
        }
    }
}
