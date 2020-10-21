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
            IList<Family> families = familyFileHandler.Families;

            int max = families.Any() ? families.Max(f => f.Id) : 0;

            toAdd.Id = ++max;
            int same = families.Where(f =>
                (f.Id == toAdd.Id || (f.HouseNumber == toAdd.HouseNumber && f.StreetName == toAdd.StreetName))).Count();

            if (same < 1)
            {
                families.Add(toAdd);
                familyFileHandler.SaveChanges();
                return true;
            }
            else
                throw new Exception("This family already exists");
        }
        public bool AddAdultToFamily(Adult adultToAdd, Family familyToJoin)
        {
            IList<Family> families = familyFileHandler.Families;
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
                familyFileHandler.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Family already has 2 adults.");
            }
        }

        public IList<Adult> GetAdults()
        {
            IList<Family> families = familyFileHandler.Families;
            IList<Adult> adults = CollectAdults(families);
            return adults;
        }


        public bool RemoveAdult(Adult toRemove)
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
