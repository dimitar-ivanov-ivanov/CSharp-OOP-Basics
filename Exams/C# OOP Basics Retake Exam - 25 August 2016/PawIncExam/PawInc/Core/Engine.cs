namespace PawInc.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private CommandCenter commandCenter;

        public Engine(CommandCenter commandCenter)
        {
            this.commandCenter = commandCenter;
        }

        public void Run()
        {
            var args = Console.ReadLine()
                .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            while (args[0] != "Paw Paw Pawah")
            {
                var command = args[0];

                switch (command)
                {
                    case "RegisterCleansingCenter":
                        var name = args[1];
                        commandCenter.RegisterCleansingCenter(name);
                        break;
                    case "RegisterAdoptionCenter":
                        name = args[1];
                        commandCenter.RegisterAdoptionCenter(name);
                        break;
                    case "RegisterDog":
                        name = args[1];
                        var age = int.Parse(args[2]);
                        var learnedCommands = int.Parse(args[3]);
                        var adoptionCenterName = args[4];
                        commandCenter.RegisterDog(name, age, learnedCommands, adoptionCenterName);
                        break;
                    case "RegisterCat":
                        name = args[1];
                        age = int.Parse(args[2]);
                        var intelligenceCoefficient = int.Parse(args[3]);
                        adoptionCenterName = args[4];
                        commandCenter.RegisterCat(name, age, intelligenceCoefficient, adoptionCenterName);
                        break;
                    case "SendForCleansing":
                        adoptionCenterName = args[1];
                        var cleansingCenterName = args[2];
                        commandCenter.SendForCleansing(adoptionCenterName, cleansingCenterName);
                        break;
                    case "Cleanse":
                        cleansingCenterName = args[1];
                        commandCenter.Cleanse(cleansingCenterName);
                        break;
                    case "Adopt":
                        adoptionCenterName = args[1];
                        commandCenter.Adopt(adoptionCenterName);
                        break;
                    default:
                        break;
                }

                args = Console.ReadLine()
               .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => x.Trim())
               .ToArray();
            }

            Console.Write(commandCenter.Output());
        }
    }
}
