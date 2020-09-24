using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAllEvenUpTo(10);
            PrintAllDivisibleByIn(3,10);
        }

        static void PrintAllEvenUpTo(int number)
        {
            PrintAllDivisibleByIn(2, number);
        }

        static void PrintAllDivisibleByIn(int y, int x)
        {
            for (int i = 0; i <= x; i++)
            {
                if (i % y == 0)
                    Console.WriteLine(i);
            }
        }
        
    }
}
