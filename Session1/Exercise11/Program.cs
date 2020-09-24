using System;
using System.Linq;

namespace Exercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountClumps(new int[] { 1, 1, 0, 1, 2, 2, 0, 0, 0, 0, 1, 1 }));
            Console.WriteLine(CountClumps(new int[] { 1, 1, 0, 1, 1, 1 }));
        }
        static int CountClumps(int[] ints)
        {
            int clumps = 0;
            int count = 0;
            for (int i = 0; i < ints.Length - 1; i++)
            {
                if (ints[i] == ints[i + 1])
                {
                    if (count == 0)
                        clumps++;
                    count++;
                }
                else
                    count = 0;
            }
            return clumps;
        }
    }
}
