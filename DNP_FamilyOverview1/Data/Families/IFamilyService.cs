using DNP_FamilyOverview1.Models.Families;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNP_FamilyOverview1.Data.Families
{
    public interface IFamilyService
    {
        IList<Family> GetFamilies();
        bool RemoveFamily(Family toRemove);
        bool AddFamily(Family toAdd);
    }
}
