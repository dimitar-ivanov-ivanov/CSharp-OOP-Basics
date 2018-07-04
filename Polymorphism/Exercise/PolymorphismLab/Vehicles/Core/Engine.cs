namespace Vehicles.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Vehicles.Models;

    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            var car = GetCar();
            var truck = GetTruck();
            var n = int.Parse(Console.ReadLine());

            var carMethods = car
                .GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Static | BindingFlags.Instance);

            var truckMethods = truck
              .GetType()
              .GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
               BindingFlags.Static | BindingFlags.Instance);

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var vechileType = args[1];
                var methodName = args[0];
                var second = double.Parse(args[2]);

                switch (vechileType)
                {
                    case "Car":
                        var methodToInvoke = carMethods
                            .FirstOrDefault(x => x.Name == methodName);

                        methodToInvoke.Invoke(car, new object[] { second });

                        break;
                    case "Truck":
                        methodToInvoke = truckMethods
                          .FirstOrDefault(x => x.Name == methodName);

                        methodToInvoke.Invoke(truck, new object[] { second });
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private Car GetCar()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new Car(double.Parse(args[1]), double.Parse(args[2]));
        }

        private Truck GetTruck()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new Truck(double.Parse(args[1]), double.Parse(args[2]));
        }
    }
}
