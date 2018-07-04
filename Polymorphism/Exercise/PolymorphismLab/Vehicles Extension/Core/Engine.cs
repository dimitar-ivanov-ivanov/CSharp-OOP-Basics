namespace Vehicles_Extension.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Vehicles_Extension.Models;

    public class Engine
    {
        private const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic |
               BindingFlags.Static | BindingFlags.Instance;

        public Engine()
        {

        }

        public void Run()
        {
            var car = GetCar();
            var truck = GetTruck();
            var bus = GetBus();
            var n = int.Parse(Console.ReadLine());

            var carMethods = car
                .GetType()
                .GetMethods(Flags);

            var truckMethods = truck
              .GetType()
              .GetMethods(Flags);

            var busMethods = bus
              .GetType()
              .GetMethods(Flags);

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var vechileType = args[1];
                var methodName = args[0];
                var second = double.Parse(args[2]);

                try
                {
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
                        case "Bus":
                            methodToInvoke = busMethods
                            .FirstOrDefault(x => x.Name == methodName);

                            methodToInvoke.Invoke(bus, new object[] { second });
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    while(ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private Car GetCar()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new Car(double.Parse(args[1]), double.Parse(args[2]), double.Parse(args[3]));
        }

        private Truck GetTruck()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new Truck(double.Parse(args[1]), double.Parse(args[2]), double.Parse(args[3]));
        }

        private Bus GetBus()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new Bus(double.Parse(args[1]), double.Parse(args[2]), double.Parse(args[3]));
        }
    }
}
