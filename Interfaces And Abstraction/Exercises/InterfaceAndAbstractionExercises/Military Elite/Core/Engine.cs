namespace Military_Elite.Core
{
    using Military_Elite.Contracts;
    using Military_Elite.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private Dictionary<int, IPrivate> privates;
        private const string TerminatingCommand = "End";

        public Engine()
        {
            this.privates = new Dictionary<int, IPrivate>();
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != TerminatingCommand)
            {
                var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var soldierType = args[0];
                var nonParsedParams = args.Skip(1).ToArray();

                try
                {
                    switch (soldierType)
                    {
                        case "Private":
                            var privateSoldier = InitializePrivate(nonParsedParams);
                            privates.Add(privateSoldier.Id, privateSoldier);
                            Console.WriteLine(privateSoldier);
                            break;
                        case "LeutenantGeneral":
                            Console.WriteLine(InitializeLeutenant(nonParsedParams));
                            break;
                        case "Engineer":
                            Console.WriteLine(InitializeEngineer(nonParsedParams));
                            break;
                        case "Commando":
                            Console.WriteLine(InitializeCommando(nonParsedParams));
                            break;
                        case "Spy":
                            Console.WriteLine(InitializeSpy(nonParsedParams));
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException) { }

                input = Console.ReadLine();
            }
        }

        private IPrivate InitializePrivate(string[] args)
        {
            var id = int.Parse(args[0]);
            var firstName = args[1];
            var lastName = args[2];
            var salary = double.Parse(args[3]);

            return new Private(id, firstName, lastName, salary);
        }

        private ISpy InitializeSpy(string[] args)
        {
            var id = int.Parse(args[0]);
            var firstName = args[1];
            var lastName = args[2];
            var codeNumber = int.Parse(args[3]);

            return new Spy(id, firstName, lastName, codeNumber);
        }

        private ILeutenantGeneral InitializeLeutenant(string[] args)
        {
            var id = int.Parse(args[0]);
            var firstName = args[1];
            var lastName = args[2];
            var salary = double.Parse(args[3]);
            var privatesIds = args.Skip(4)
                .Select(x => int.Parse(x))
                .ToArray();

            var privates = new List<IPrivate>();

            for (int i = 0; i < privatesIds.Length; i++)
            {
                if (this.privates.ContainsKey(privatesIds[i]))
                {
                    privates.Add(this.privates[privatesIds[i]]);
                }
            }

            return new LeutenantGeneral(id, firstName, lastName, salary, privates);
        }

        private IEngineer InitializeEngineer(string[] args)
        {
            var id = int.Parse(args[0]);
            var firstName = args[1];
            var lastName = args[2];
            var salary = double.Parse(args[3]);
            var corps = args[4];
            var repairs = new List<IRepair>();

            for (int i = 5; i < args.Length; i += 2)
            {
                var partName = args[i];
                var hours = int.Parse(args[i + 1]);
                var repair = new Repair(partName, hours);
                repairs.Add(repair);
            }

            return new Engineer(id, firstName, lastName, salary, corps, repairs);
        }

        private ICommando InitializeCommando(string[] args)
        {
            var id = int.Parse(args[0]);
            var firstName = args[1];
            var lastName = args[2];
            var salary = double.Parse(args[3]);
            var corps = args[4];
            var missions = args.Skip(5).ToList();

            return new Commando(id, firstName, lastName, salary, corps, missions);
        }
    }
}
