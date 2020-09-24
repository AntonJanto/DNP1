using System;
using Cars;
namespace Exercise2x05
{
    class Program
    {
        static void Main(string[] args)
        {
            var allCars = Car.CarGarage();
            var redCars = allCars.FindAll(Car.IsOfRedColor);
            foreach (var car in redCars)
            {
                Console.WriteLine(car);
            }
            allCars.FindAll(car => car.IsManualShift).ForEach(car => Console.WriteLine(car));
            allCars.FindAll(car => car.EngineSize > 2).ForEach(car => Console.WriteLine(car));
            allCars.FindAll(car => car.FuelEconomy < 7).ForEach(car => Console.WriteLine(car));
            allCars.FindAll(car => car.FuelEconomy < 7 && !car.IsManualShift).ForEach(car => Console.WriteLine(car));
        }
    }
}
