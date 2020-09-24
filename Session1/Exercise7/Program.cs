using System;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MakeAbba("Hey","You"));
        }

        static string MakeAbba(string a, string b) => $"{a}{b}{b}{a}";
    }
}
