using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ViaExample.DataAccess;
using ViaExample.Models;

namespace ViaExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new Program().UpdateCourse();
            //await new Program().InsertCourseAsync();
            //await new Program().InsertProgrammeAsync();
        }
        
        private async Task InsertCourseAsync()
        {
            var dnp1 = new Course
            {
                Id = "DNP1",
                Name = "Internet Technologies, C# and .NET",
                Semester = 3,
                IsElective = false
            };

            using (var dbContext = new ViaDbContext())
            {
                await dbContext.Courses.AddAsync(dnp1);
                await dbContext.SaveChangesAsync();
            }
        }

        private async Task InsertProgrammeAsync()
        {
            var SDJ2 = new Course()
            {
                Id = "SDJ2",
                Name = "Software Development with Java and UML 2",
                Semester = 2,
                IsElective = false,
            };
            var GMD = new Course()
            {
                Id = "GMD1",
                Name = "Game Development",
                Semester = 6,
                IsElective = true
            };

            var courses = new List<Course> {GMD, SDJ2};

            var software = new Programme()
            {
                Location = "Horsens",
                Name = "Software Technology Engineering",
                ShortName = "Software",
                HeadOfDepartment = "AHM",
                Courses = courses
            };

            using (var dbContext = new ViaDbContext())
            {
                await dbContext.Programmes.AddAsync(software);
                await dbContext.SaveChangesAsync();
            }
        }

        private async Task UpdateCourse()
        {
            using (var dbContext = new ViaDbContext())
            {
                IQueryable<Course> result = dbContext.Courses.Where(c => c.Id.Equals("DNP1"));

                Course dnp = await dbContext.Courses.FirstAsync(c => c.Id.Equals("DNP1"));

                Programme softwareProgramme = await dbContext.Programmes
                    .Include(p => p.Courses)
                    .FirstAsync(p => p.ShortName.Equals("Software"));
                
                softwareProgramme.Courses.Add(dnp);
                dbContext.Update(softwareProgramme);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}