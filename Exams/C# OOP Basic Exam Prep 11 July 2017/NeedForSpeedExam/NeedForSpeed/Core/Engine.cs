using System;
using System.Linq;
using System.Reflection;

public class Engine : IEngine
{
    private const string TerminatingCommand = "Cops Are Here";

    private IReader reader;
    private IWriter writer;
    private ICarManager carManager;

    public Engine(IReader reader, IWriter writer, ICarManager carManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.carManager = carManager;
    }

    public void Run()
    {
        var input = reader.ReadLine();

        while (input != TerminatingCommand)
        {
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var methodName = args[0];

            switch (methodName)
            {
                case "register":
                    var id = int.Parse(args[1]);
                    var type = args[2];
                    var brand = args[3];
                    var model = args[4];
                    var year = int.Parse(args[5]);
                    var horsepower = int.Parse(args[6]);
                    var acceleration = int.Parse(args[7]);
                    var suspension = int.Parse(args[8]);
                    var durability = int.Parse(args[9]);

                    carManager.Register(id, type, brand, model,
                        year, horsepower, acceleration, suspension, durability);

                    break;
                case "check":
                    id = int.Parse(args[1]);
                    writer.WriteLine(carManager.Check(id));
                    break;
                case "open":
                    id = int.Parse(args[1]);
                    type = args[2];
                    var length = int.Parse(args[3]);
                    var route = args[4];
                    var prizePool = int.Parse(args[5]);

                    carManager.Open(id, type, length, route, prizePool);
                    break;
                case "participate":
                    var carId = int.Parse(args[1]);
                    var raceId = int.Parse(args[2]);

                    carManager.Participate(carId, raceId);
                    break;
                case "start":
                    raceId = int.Parse(args[1]);

                    writer.WriteLine(carManager.Start(raceId));

                    break;
                case "park":
                    carId = int.Parse(args[1]);
                    carManager.Park(carId);
                    break;
                case "unpark":
                    carId = int.Parse(args[1]);
                    carManager.Unpark(carId);
                    break;
                case "tune":
                    var tuneIndex = int.Parse(args[1]);
                    var tuneAddOn = args[2];
                    carManager.Tune(tuneIndex, tuneAddOn);
                    break;
                default:
                    break;
            }

            input = reader.ReadLine();
        }
    }
}