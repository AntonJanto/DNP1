using System;
using System.Collections.Generic;
using System.Text;

namespace BirdWatchers
{
    class Watcher
    {
        private static int id = 0;
        private int myId;
        private bool isDeaf = false;
        public Watcher()
        {
            var RNG = new Random();
            isDeaf = RNG.NextDouble() < 0.2;
            myId = Watcher.NextId();
        }

        public void WatcherReactsToBirds(string birdBehaviour)
        {
            var who = $"Watcher {myId}: ";
            if (!isDeaf)
            {
                switch (birdBehaviour)
                {
                    case "flaps wings":
                        Console.WriteLine(who + "Woow!");
                        break;
                    case "sings":
                        Console.WriteLine(who + "That is a real beauty!");
                        break;
                    case "does aerobatics":
                        Console.WriteLine(who + "Incredible, what they can do!");
                        break;
                    default:
                        Console.WriteLine(who + "What the fuck is going on?!");
                        break;
                }
            }
            else
                Console.WriteLine(who + "HUmmaRghuhgjk");
        }
        private static int NextId() => id++;
    }
}
