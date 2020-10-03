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


        public IList<Family> GetFamilies()
        {
            return familyFileHandler.Families;
        }

        public bool RemoveFamily(Family toRemove)
        {
            bool removed = familyFileHandler.Families.Remove(toRemove);
            if (removed)
            {
                familyFileHandler.SaveChanges();
            }
            return removed;
        }
        public bool AddFamily(Family toAdd)
        {
            int max = familyFileHandler.Families.Any() ? familyFileHandler.Families.Max(f => f.Id) : 0;
            toAdd.Id = ++max;
            int same = familyFileHandler.Families.Where(f => f.Id == toAdd.Id || (f.HouseNumber == toAdd.HouseNumber && f.StreetName == toAdd.StreetName)).Count();
            if (same < 1)
            {
                familyFileHandler.Families.Add(toAdd);
                familyFileHandler.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
