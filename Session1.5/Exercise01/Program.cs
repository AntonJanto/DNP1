using System;

namespace Exercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            var student1 = new DNPStudent();
            var student2 = (Student)student1;

            student1.SayHi();
            student2.SayHi();
        }
    }
}
