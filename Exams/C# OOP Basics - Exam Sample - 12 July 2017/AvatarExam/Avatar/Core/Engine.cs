using System;
using System.Linq;

public class Engine
{
    private const string TerminatingCommand = "Quit";

    private NationsBuilder nationsBuilder;

    public Engine(NationsBuilder nationsBuilder)
    {
        this.nationsBuilder = nationsBuilder;
    }

    public void Run()
    {
        var input = Console.ReadLine();

        while(input != TerminatingCommand)
        {
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var methodName = args[0];

            var argsToPass = args.Skip(1).ToList();

            switch (methodName)
            {
                case "Bender":
                    nationsBuilder.AssignBender(argsToPass);
                    break;
                case "Monument":
                    nationsBuilder.AssignMonument(argsToPass);
                    break;
                case "Status":
                    var nationsType = argsToPass[0];
                    Console.WriteLine(nationsBuilder.GetStatus(nationsType));
                    break;
                case "War":
                    nationsType = argsToPass[0];
                    nationsBuilder.IssueWar(nationsType);
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(nationsBuilder.GetWarsRecord());
    }
}
