using Microsoft.EntityFrameworkCore;
using ViaExample.Models;

namespace ViaExample.DataAccess
{
    public class ViaDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Programme> Programmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\anton\DNP1\Session9\ViaExample\VIA.db");
        }
    }
}