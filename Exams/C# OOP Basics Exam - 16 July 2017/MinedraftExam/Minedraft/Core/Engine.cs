using System;
using System.Linq;

public class Engine
{
    private const string TerminatingCommand = "Shutdown";

    private DraftManager draftManager;

    public Engine(DraftManager draftManager)
    {
        this.draftManager = draftManager;
    }

    public void Run()
    {
        var input = Console.ReadLine();

        while(input != TerminatingCommand)
        {
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var commandName = args[0];
            var commandArgs = args.Skip(1).ToList();
            var result = string.Empty;

            switch (commandName)
            {
                case "RegisterHarvester":
                    result = draftManager.RegisterHarvester(commandArgs);
                    break;
                case "RegisterProvider":
                    result = draftManager.RegisterProvider(commandArgs);
                    break;
                case "Day":
                    result = draftManager.Day();
                    break;
                case "Mode":
                    result = draftManager.Mode(commandArgs);
                    break;
                case "Check":
                    result = draftManager.Check(commandArgs);
                    break;
                default:
                    break;
            }

            Console.WriteLine(result);
            input = Console.ReadLine();
        }

        Console.WriteLine(draftManager.ShutDown());
    }
}

