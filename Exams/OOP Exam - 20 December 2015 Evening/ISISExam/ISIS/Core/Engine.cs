namespace ISIS.Core
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
                .Split(new[] { '.', '(', ')', ',' })
                .Select(x => x.Trim())
                .ToArray();

            while (args[1] != "apocalypse")
            {
                var command = args[1];

                switch (command)
                {
                    case "create":
                        var name = args[0];
                        var health = int.Parse(args[2]);
                        var damage = int.Parse(args[3]);
                        var warEffect = args[4];
                        var attackType = args[5];

                        commandCenter.CreateGroup(name, health, damage, warEffect, attackType);
                        break;
                    case "attack":
                        var attacker = args[0];
                        var target = args[2];
                        commandCenter.Attack(attacker, target);
                        break;
                    case "akbar":
                        commandCenter.Akbar();
                        break;
                    case "status":
                        Console.Write(commandCenter.Status());
                        break;
                    case "getEvents":
                        commandCenter.ToggleEffect();
                        break;
                    default:
                        break;
                }

                args = Console.ReadLine()
                  .Split(new[] { '.', '(', ')', ',' })
                  .Select(x => x.Trim())
                  .ToArray();
            }
        }
    }
}
