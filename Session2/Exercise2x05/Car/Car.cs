
using System.Collections.Generic;

namespace Cars
{
    public class Car
    {
        public string Color { get; set; }
        public double EngineSize { get; set; }
        public double FuelEconomy { get; set; }
        public bool IsManualShift { get; set; }

        public override string ToString()
        {
            return $"Color: {Color}\n" +
                $"EngineSize: {EngineSize}L\n" +
                $"FuelEconomy: {FuelEconomy}l/100km\n" +
                $"Manual shifting: {(IsManualShift ? "Yes" : "No")}\n";
        }

        public static bool IsOfRedColor(Car car)
        {
            return car.Color == "red";
        }
        public static List<Car> CarGarage()
        {
            var cars = new List<Car>();
            cars.Add(new Car
            {
                Color = "red",
                EngineSize = 1.5,
                FuelEconomy = 5.6,
                IsManualShift = true
            });
            cars.Add(new Car
            {
                Color = "blue",
                EngineSize = 1.9,
                FuelEconomy = 7,
                IsManualShift = false
            });
            cars.Add(new Car
            {
                Color = "silver",
                EngineSize = 1.2,
                FuelEconomy = 3.4,
                IsManualShift = true
            });
            cars.Add(new Car
            {
                Color = "green",
                EngineSize = 5.6,
                FuelEconomy = 12.8,
                IsManualShift = true
            });
            cars.Add(new Car
            {
                Color = "red",
                EngineSize = 2.5,
                FuelEconomy = 7.2,
                IsManualShift = false
            });
            return cars;
        }
    }
}
