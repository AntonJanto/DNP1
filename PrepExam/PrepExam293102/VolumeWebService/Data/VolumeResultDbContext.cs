using Microsoft.EntityFrameworkCore;

namespace VolumeWebService.Data
{
    public class VolumeResultDbContext : DbContext
    {
        public DbSet<VolumeResult> VolumeResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                @"Data Source = C:\Users\anton\DNP1\PrepExam\PrepExam293102\VolumeWebService\VolumeResults.db");
        }
    }
}