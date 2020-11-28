using FamilyAPI.Models.Families;
using Microsoft.EntityFrameworkCore;

namespace FamilyAPI.Data.DataAccess
{
    public class FamilyApiContext : DbContext
    {
        public DbSet<Family> Families { get; set; }
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource = C:\Users\anton\DNP1\FamilyAPI\Data\DataAccess\FamilyDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>()
                .HasKey(f => new
                {
                    f.HouseNumber,
                    f.StreetName
                });
            
            
            modelBuilder.Entity<ChildInterest>()
                .HasKey(ci =>
                    new
                    {
                        ci.ChildId,
                        ci.InterestId
                    });

            modelBuilder.Entity<ChildInterest>()
                .HasOne(ci => ci.Child)
                .WithMany(child => child.ChildInterests)
                .HasForeignKey(ci => ci.ChildId);
            
            modelBuilder.Entity<ChildInterest>()
                .HasOne(ci => ci.Interest)
                .WithMany(interest => interest.ChildInterests)
                .HasForeignKey(ci => ci.InterestId);
            
        }
    }
}