namespace Blobs.Core
{
    using System;

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
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "drop")
            {
                var command = args[0];

                switch (command)
                {
                    case "create":
                        var name = args[1];
                        var health = int.Parse(args[2]);
                        var damage = int.Parse(args[3]);
                        var behavior = args[4];
                        var attack = args[5];
                        commandCenter.CreateBlob(name, health, damage, behavior, attack);
                        break;
                    case "attack":
                        var attacker = args[1];
                        var target = args[2];
                        commandCenter.Attack(attacker, target);
                        break;
                    case "pass":
                        commandCenter.Pass();
                        break;
                    case "status":
                        Console.Write(commandCenter.Status());
                        break;
                    default:
                        break;
                }

                args = Console.ReadLine()
              .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            }
        }
    }
}
