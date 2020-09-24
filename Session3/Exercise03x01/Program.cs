using System;
using System.Collections.Generic;
using System.Text.Json;
using PersonNS;

namespace Exercise03x01
{
    class Program
    {
        static void Main(string[] args)
        {
            var Adam = new Person()
            {
                FirstName = "Adam",
                LastName = "Ondrasko",
                Age = 21,
                Height = 172.9,
                IsMarried = true,
                Sex = 'M',
                Hobbies = new string[] {"Karate", "Fifa", "Pole Dance"}
            };

            var Honzo = new Person()
            {
                FirstName = "Jan",
                LastName = "Vasilcenko",
                Age = 21,
                Height = 183.5,
                IsMarried = false,
                Sex = 'M',
                Hobbies = new string[] { "Game Development", "Klarka predsa" }
            };

            var MarkoGula = new Person()
            {
                FirstName = "Marko",
                LastName = "Gula",
                Age = 20,
                Height = 176,
                IsMarried = false,
                Sex = 'M',
                Hobbies = new string[] { "Spinky Bink", "Binky Spink" }
            };

            var roomMates = new List<Person>();
            roomMates.Add(Honzo);
            roomMates.Add(Adam);
            roomMates.Add(MarkoGula);

            string jsonFormatted = JsonSerializer.Serialize(roomMates, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonFormatted);

        }
    }
}
