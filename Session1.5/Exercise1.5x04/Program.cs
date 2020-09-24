using System;
using System.Collections.Generic;
using Zoo;

namespace Exercise1._5x04
{
    class Program
    {
        static void Main(string[] args)
        {
            var zoo = new List<Animal>();
            zoo.Add(new Animal()
            {
                Type = "Cheetah",
                Weight = 65,
                Speed = 120
            });

            zoo.Add(new Animal()
            {
                Type = "Hippopotamus",
                Weight = 265,
                Speed = 20
            });
            zoo.Add(new Animal()
            {
                Type = "Monkey",
                Weight = 35,
                Speed = 28
            });
            zoo.Add(new Animal()
            {
                Type = "Parrot",
                Weight = 2.5,
                Speed = 70
            });
            zoo.Add(new Animal()
            {
                Type = "Swallow",
                Weight = 0.3,
                Speed = 55
            });
            zoo.Add(new Animal()
            {
                Type = "T-Rex",
                Weight = 356.56,
                Speed = 45
            });

            foreach (Animal animal in zoo)
                Console.WriteLine(animal + "\n");

            Console.WriteLine();


            Console.WriteLine();

            zoo.Sort();
            foreach (Animal animal in zoo)
                Console.WriteLine(animal);
        }
    }
}
