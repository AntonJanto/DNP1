using System;

namespace Exercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NTwice("He", 3));
        }

        static string NTwice(string word, int n) => n > word.Length ? word+word: word.Substring(0, n) + word.Substring(word.Length - n);
    }
}
