using System;
using System.Threading;

namespace Exercise2x04
{
    class Program
    {
        static void Main(string[] args)
        {
            var wr = new WaitingRoom();
            var p0 = new Patient(wr);
            var p1 = new Patient(wr);
            var p2 = new Patient(wr);
            var p3 = new Patient(wr);
            wr.RunWaitingRoom();
        }
    }
}
