using System;

namespace Exercise2x02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Time(15, 26));
            Console.WriteLine(new Time(9, 46));
            Console.WriteLine(new Time(23, 89));
            var time4 = new Time(23, 59);
            Console.WriteLine(time4);
            time4.AddMinutes(1);
            Console.WriteLine(time4);
            time4.AddMinutes(3);
            Console.WriteLine(time4);
            time4.AddMinutes(1500);
            Console.WriteLine(time4);
            time4.RemoveMinutes(1380);
            Console.WriteLine(time4);

        }
    }

    struct Time
    {
        private int _minutes;
        public int Minutes
        {
            get => _minutes;
            set => _minutes = value % 1440 < 0 ? value % 1440 + 1440: value % 1440; 
        }
        public Time(int hours, int minutes)
        {
            _minutes = 0;
            Minutes = (minutes + hours * 60);
        }
        public void AddMinutes(int mins) => Minutes += mins;
        public void RemoveMinutes(int mins) => Minutes -= mins;
        public override string ToString()
        {
            int min = Minutes % 60;
            int hour = Minutes / 60;
            return String.Format("{0:D2}:{1:D2}", hour, min);
        }
    }
}
