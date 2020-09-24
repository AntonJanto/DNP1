using System;
using System.Threading;

namespace BirdWatchers
{
    public class Bird
    {
        public Action<string> BirdBehaviour;
        private readonly string[] behaviours = { "flaps wings", "sings", "does aerobatics" };
        public void MakeBirdFly()
        {
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < behaviours.Length; i++)
                {
                    Console.WriteLine($"\n\nThe bird {behaviours[i]}.");
                    BirdBehaviour?.Invoke(behaviours[i]);
                    Thread.Sleep(1500);
                }
            }
        }
    } 
}
