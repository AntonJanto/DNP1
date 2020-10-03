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
        private readonly FileContext familyFile;

        public FamilyService()
        {
            familyFile = new FileContext();
        }

        public IList<Family> GetFamilies()
        {
            return familyFile.Families;
        }

        public bool RemoveFamily(Family toRemove)
        {
            bool removed = familyFile.Families.Remove(toRemove);
            if (removed)
            {
                familyFile.SaveChanges();
            }
            return removed;
        }
    }
}
