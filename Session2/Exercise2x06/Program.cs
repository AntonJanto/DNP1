using BirdWatchers;
using System;

namespace Exercise2x06
{
    class Program
    {
        static void Main(string[] args)
        {
            var birdie = new Bird();
            var w1 = new Watcher();
            var w2 = new Watcher();
            var w3 = new Watcher();

            birdie.BirdBehaviour += w1.WatcherReactsToBirds;
            birdie.BirdBehaviour += w2.WatcherReactsToBirds;
            birdie.BirdBehaviour += w3.WatcherReactsToBirds;

            birdie.MakeBirdFly();
        }
    }
}
