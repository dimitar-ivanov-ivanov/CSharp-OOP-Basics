namespace Border_Control.Models
{
    using Border_Control.Contracts;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private const string TerminatingCommand = "End";

        public void Run()
        {
            var identifables = GetIdentifiables();
            var fakeId = Console.ReadLine();

            foreach (var identifable in identifables)
            {
                if (identifable.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(identifable.Id);
                }
            }
        }

        public IList<IIdentifiable> GetIdentifiables()
        {
            var list = new List<IIdentifiable>();

            var input = Console.ReadLine();

            while (input != TerminatingCommand)
            {
                var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var first = args[0];
                var id = args[args.Length - 1];

                if (args.Length == 3)
                {
                    var age = int.Parse(args[1]);
                    list.Add(new Citizen(args[0], age, id));
                }
                else if (args.Length == 2)
                {
                    list.Add(new Robot(first, id));
                }

                input = Console.ReadLine();
            }

            return list;
        }
    }
}
