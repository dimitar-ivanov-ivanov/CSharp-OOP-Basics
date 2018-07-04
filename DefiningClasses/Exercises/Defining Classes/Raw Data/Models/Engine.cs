namespace Raw_Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var car = Car.Parse(Console.ReadLine());
                cars.Add(car);
            }

            var cargoType = Console.ReadLine();
            var result = cars.Where
                (x => x.Cargo.Type == cargoType);

            if (cargoType == "fragile")
            {
                result = result
                    .Where(x => x.Tyres.Any(y => y.Pressure < 1));
            }
            else if (cargoType == "flamable")
            {
                result = result
                    .Where(x => x.Engine.Power > 250);
            }

            foreach (var car in result)
            {
                Console.WriteLine(car);
            }
        }
    }
}
