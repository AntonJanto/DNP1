using System;
using MathLib;


namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculator.Add(new int[] { 1, 2, 3 }));
            Console.WriteLine(Calculator.Add(2, 4));

            Console.Write("Type 2 integers: ");
            int first = Convert.ToInt32(Console.ReadLine());
            int second = Convert.ToInt32(Console.ReadLine());
            int greater = Calculator.Max(first, second);
            Console.WriteLine($"The greater of the two is: {greater}");

        }
    }
}
