namespace Speed_Racing.Models
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private const string TerminatingCommand = "End";

        public void Run()
        {
            var cars = InitializeCars();

            var input = Console.ReadLine();
            while (input != TerminatingCommand)
            {
                var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = args[1];
                var kilometers = int.Parse(args[2]);

                try
                {
                    if (cars.ContainsKey(model))
                    {
                        cars[model].Drive(kilometers);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            Print(cars);
        }

        private void Print(Dictionary<string, Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car.Value);
            }
        }

        private Dictionary<string, Car> InitializeCars()
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = args[0];
                var fuelAmount = int.Parse(args[1]);
                var fuelConsumption = double.Parse(args[2]);
                var car = new Car(model, fuelAmount, fuelConsumption);

                if (!cars.ContainsKey(model))
                {
                    cars.Add(model, car);
                }
            }

            return cars;
        }
    }
}
