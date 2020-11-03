using DNP_FamilyOverview1.Data.FileData;
using DNP_FamilyOverview1.Models.Families;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNP_FamilyOverview1.Data.Families
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
            bool removed = familyFileHandler.Families.Remove(toRemove);
            if (removed)
            {
                familyFileHandler.SaveChanges();
            }
            return removed;
        }
        public async Task<bool> AddFamilyAsync(Family toAdd)
        {
            IList<Family> families = familyFileHandler.Families;

            int same = families.Where(f =>
                (f.HouseNumber == toAdd.HouseNumber && f.StreetName == toAdd.StreetName)).Count();

            if (same < 1)
            {
                families.Add(toAdd);
                familyFileHandler.SaveChanges();
                return true;
            }
            else
                throw new Exception("This family already exists");
        }

        public async Task<bool> RemoveAdultAsync(Adult toRemove)
        {
            IList<Family> families = familyFileHandler.Families;
            foreach (var family in families)
            {
                if (family.Adults.Contains(toRemove))
                {
                    var removed = family.Adults.Remove(toRemove);
                    familyFileHandler.SaveChanges();
                    return removed;
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
    }
}
