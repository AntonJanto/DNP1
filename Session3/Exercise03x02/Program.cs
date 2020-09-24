using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using PersonNS;

namespace Exercise03x02
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
                Hobbies = new string[] { "Karate", "Fifa", "Pole Dance" }
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

            StoreObjects("roomMates.json", roomMates);

            var peopleFromFile = RestoreObjects("roomMates.json");
            Console.WriteLine(JsonSerializer.Serialize(peopleFromFile, new JsonSerializerOptions { WriteIndented = true }));
        }

        public static void StoreObjects(string fileName, List<Person> people)
        {
            using (var stream = new StreamWriter(fileName))
            {
                var dataToWrite = JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented = true });
                stream.Write(dataToWrite);
            }
        }

        public static List<Person> RestoreObjects(string fileName)
        {
            using (var stream = new StreamReader(fileName))
            {
                var result = JsonSerializer.Deserialize<List<Person>>(stream.ReadToEnd(), new JsonSerializerOptions { WriteIndented = true });
                return result;
            }
        }
    }
}
