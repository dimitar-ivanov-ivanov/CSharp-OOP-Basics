namespace Birthday_Celebrations.Models
{
    using Birthday_Celebrations.Contracts;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private const string TerminatingCommand = "End";

        public void Run()
        {
            var birthables = GetBirthables();
            var yearToFind = Console.ReadLine();

            foreach (var identifable in birthables)
            {
                if (identifable.Birthdate.EndsWith(yearToFind))
                {
                    Console.WriteLine(identifable.Birthdate);
                }
            }
        }

        public IList<IBirthable> GetBirthables()
        {
            var list = new List<IBirthable>();

            var input = Console.ReadLine();

            while (input != TerminatingCommand)
            {
                var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var identifableName = args[0];
                var firstName = args[1];

                switch (identifableName)
                {
                    case "Citizen":
                        var age = int.Parse(args[2]);
                        var id = args[3];
                        var birthdate = args[4];
                        list.Add(new Citizen(firstName, age, id, birthdate));
                        break;
                    case "Pet":
                        birthdate = args[2];
                        list.Add(new Pet(firstName, birthdate));
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            return list;
        }
    }
}
