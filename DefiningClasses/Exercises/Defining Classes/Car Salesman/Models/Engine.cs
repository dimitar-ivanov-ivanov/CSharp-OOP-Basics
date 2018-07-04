namespace Car_Salesman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var engines = GetEngines();
            var cars = GetCars(engines);
            Print(cars);
        }

        private void Print(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private List<Car> GetCars(List<CarEngine> engines)
        {
            var cars = new List<Car>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = args[0];
                var engineModel = args[1];
                var engine = engines.FirstOrDefault(x => x.Model == engineModel);

                var car = Car.Parse(model, engine, args.Skip(2).ToArray());
                cars.Add(car);
            }

            return cars;
        }

        private List<CarEngine> GetEngines()
        {
            var n = int.Parse(Console.ReadLine());
            var engines = new List<CarEngine>();

            for (int i = 0; i < n; i++)
            {
                var engine = CarEngine.Parse(Console.ReadLine());
                engines.Add(engine);
            }

            return engines;
        }
    }
}
