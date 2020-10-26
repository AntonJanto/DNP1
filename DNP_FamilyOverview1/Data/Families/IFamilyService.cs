using DNP_FamilyOverview1.Models.Families;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNP_FamilyOverview1.Data.Families
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetFamiliesAsync();
        Task<bool> RemoveFamilyAsync(Family toRemove);
        Task<bool> AddFamilyAsync(Family toAdd);
        Task<bool> AddAdultToFamilyAsync(Adult adultToAdd, Family familyToJoin);
        Task<bool> RemoveAdultAsync(Adult toRemove);
    }
}
