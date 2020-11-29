using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyAPI.Data.DataAccess;
using FamilyAPI.Models.Families;
using Microsoft.EntityFrameworkCore;

namespace FamilyAPI.Data.Families
{
    public class SqliteFamilyService : IFamilyService
    {
        private readonly FamilyApiContext _familyApiContext;

        public SqliteFamilyService(FamilyApiContext familyApiContext)
        {
            _familyApiContext = familyApiContext;
        }

        public async Task<IList<Family>> GetFamiliesAsync()
        {
            return await _familyApiContext.Families
                .Include(f => f.Adults)
                .Include(f => f.Children)
                .Include(f => f.Pets)
                .ToListAsync();
        }

        public async Task<bool> RemoveFamilyAsync(Family toRemove)
        {
            var fam = await _familyApiContext.Families
                .Include(f => f.Adults)
                .FirstOrDefaultAsync(f 
                    => f.StreetName == toRemove.StreetName && f.HouseNumber == toRemove.HouseNumber);
            var removed = _familyApiContext.Families.Remove(fam);
            await _familyApiContext.SaveChangesAsync();

            return removed.State == EntityState.Deleted;
        }

        public async Task<Family> AddFamilyAsync(Family toAdd)
        {
            var fam = await _familyApiContext.Families.AddAsync(toAdd);
            await _familyApiContext.SaveChangesAsync();
            
            return await _familyApiContext.Families
                .FindAsync(fam.Entity.StreetName, fam.Entity.HouseNumber);
        }

        public async Task<bool> RemoveAdultAsync(int toRemove)
        {
            var adult = await _familyApiContext.Adults.FindAsync(toRemove);
            var removed = _familyApiContext.Adults.Remove(adult);
            await _familyApiContext.SaveChangesAsync();
            return removed.State == EntityState.Deleted;
        }
    }
} 