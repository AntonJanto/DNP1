using FamilyAPI.Models.Families;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyAPI.Data.Families
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetFamiliesAsync();
        Task<bool> RemoveFamilyAsync(Family toRemove);
        Task<Family> AddFamilyAsync(Family toAdd);
        Task<bool> RemoveAdultAsync(int toRemove);
    }
}
