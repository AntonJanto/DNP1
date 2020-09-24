using System;

namespace Exercise01
{
    public class Student
    {
        public void SayHi()
        {
            Console.WriteLine("Hi, I am a student");
        }
    }

    public class DNPStudent : Student
    {
        //new      - at upcasting a base class method is called
        //override - at upcasting a derived class method is called
        new public void SayHi()
        {
            base.SayHi();
            Console.WriteLine("Hi, I am a DNP student!");
        }
    }
}