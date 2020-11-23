using Microsoft.EntityFrameworkCore;
using StudentCourse_Many_To_Many.DataAccess;
using StudentCourse_Many_To_Many.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using (var mtmContext = new ManyToManyContext())
{
    Console.WriteLine("***************");
    Console.WriteLine("Many-to-many ex");
    Console.WriteLine("***************");

    //Console.WriteLine("Adding dnp1 and sdj2");
    //await AddTwoCoursesAsync(mtmContext);

    //Console.WriteLine("Adding Steve");
    //await AddOneSteve(mtmContext);

    //Console.WriteLine("Enrolling steve to dnp1");
    //await EnrollSteveToCourse(mtmContext, "IT-DNP1Y-A20");

    //Console.WriteLine("Enrolling steve to sdj2");
    //await EnrollSteveToCourse(mtmContext, "IT-SDJ2-A20");

    //Console.WriteLine("Printing Steve's courses");
    //await WhichCoursesIsSteveEnrolledIn(mtmContext);

    Console.WriteLine("Drop steve from sdj2");
    await DropSteveFromCourse(mtmContext);
}

async Task DropSteveFromCourse(ManyToManyContext ctx)
{
    var steve = await ctx.Students
        .Include(s => s.Courses)
        .FirstAsync(s => s.StudentNum == 123456);
    var course = await ctx.Courses.FindAsync("IT-SDJ2-A20");
    steve.Courses.Remove(course);

    await ctx.SaveChangesAsync();
}

async Task WhichCoursesIsSteveEnrolledIn(ManyToManyContext ctx)
{
    var courses = await ctx.Students
        .Where(s => s.StudentNum == 123456)
        .SelectMany(s => s.Courses)
        .ToListAsync();

    Console.WriteLine(
        JsonSerializer.Serialize(courses, new JsonSerializerOptions
        {
            WriteIndented = true
        }));
}

async Task EnrollSteveToCourse(ManyToManyContext ctx, string courseCode)
{
    Student steve = await ctx.Students.FindAsync(123456);
    var course = await ctx.Courses.FindAsync(courseCode);

    steve.Courses ??= new List<Course>();
    steve.Courses.Add(course);
    ctx.Update(steve);
    await ctx.SaveChangesAsync();
}

async Task AddOneSteve(ManyToManyContext ctx)
{
    var steveStudent = new Student
    {
        FirstName = "Steve",
        LastName = "Doe",
        Email = "123456@via.dk",
        StudentNum = 123456
    };
    await ctx.Students.AddAsync(steveStudent);
    await ctx.SaveChangesAsync();
}

async Task AddTwoCoursesAsync(ManyToManyContext ctx)
{
    var sdj2 = new Course
    {
        Abbreviation = "SDJ2",
        Name = "Software Development with UML and Java 2",
        Semester = 2,
        CourseCode = "IT-SDJ2-A20",
        ECTS = 10
    };
    var dnp1 = new Course
    {
        Abbreviation = "DNP1",
        Name = "I forgot the actual name",
        Semester = 3,
        CourseCode = "IT-DNP1Y-A20",
        ECTS = 5
    };
    await ctx.Courses.AddAsync(dnp1);
    await ctx.Courses.AddAsync(sdj2);
    await ctx.SaveChangesAsync();
}
