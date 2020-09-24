using System;
using System.Linq;

namespace Exercise10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BigDiff(new int[] { 1,2,5,90,0,56 }));
            Console.WriteLine(BigDiff(new int[] { 10,11 }));
            Console.WriteLine(BigDiff(new int[] { 5,9,3 }));
        }

        static int BigDiff(int[] ints) => ints.Max() - ints.Min();
    }
}
