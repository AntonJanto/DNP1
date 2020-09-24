using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Player
    {
        public void Shout(string what)
            => Console.WriteLine(what);

        public void Shout(int num) 
            => Console.WriteLine($"{num} is my lucky number!");

        public void Shout(Enemy enemy)
            => Console.WriteLine($"The enemy can do " +
                $"{enemy.Damage} damage to me.");
    }
}
