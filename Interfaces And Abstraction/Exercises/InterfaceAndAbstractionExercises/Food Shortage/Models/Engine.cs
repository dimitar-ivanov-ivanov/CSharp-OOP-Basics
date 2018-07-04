namespace Food_Shortage.Models
{
    using Food_Shortage.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private const string TerminatingCommand = "End";

        public void Run()
        {
            var citizens = GetCitizens();
            PeopleBuyingFood(citizens);
        }

        private void PeopleBuyingFood(IList<ICitizen> citizens)
        {
            var input = Console.ReadLine();

            while (input != TerminatingCommand)
            {
                var citizen = citizens.FirstOrDefault(x => x.Name == input);
                if (citizen != null)
                {
                    citizen.BuyFood();
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(citizens.Sum(x => x.Food));
        }

        public IList<ICitizen> GetCitizens()
        {
            var list = new List<ICitizen>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var first = args[0];
                var age = int.Parse(args[1]);

                if (args.Length == 3)
                {
                    var group = args[2];
                    list.Add(new Rebel(first, age, group));
                }
                else
                {
                    var id = args[2];
                    var birthdate = args[3];
                    list.Add(new Citizen(first, age, id, birthdate));
                }
            }

            return list;
        }
    }
}
