using System;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MakeOutWord("<<>>","Hello World!"));
        }

        static string MakeOutWord(string outer, string word)
        { return $"{outer[0]}{outer[1]}{word}{outer[2]}{outer[3]}"; }
    }
}
