using Game;

namespace Exercise2._5x01
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();

            player.Shout("For glory!");
            player.Shout(25);
            player.Shout(new Enemy { Damage = 10 });
        }
    }
}
