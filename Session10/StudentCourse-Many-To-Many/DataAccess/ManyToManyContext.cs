using Microsoft.EntityFrameworkCore;
using StudentCourse_Many_To_Many.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCourse_Many_To_Many.DataAccess
{
    class ManyToManyContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // name of database
            optionsBuilder
                .UseSqlite(@"Data Source = C:\Users\anton\DNP1\Session10\StudentCourse-Many-To-Many\ManyToMany.db")
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
