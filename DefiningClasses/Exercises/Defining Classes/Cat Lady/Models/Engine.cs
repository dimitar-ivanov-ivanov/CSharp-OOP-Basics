namespace Cat_Lady.Models
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private Dictionary<string, Cat> cats;
        private const string TerminatingCommand = "End";

        public Engine()
        {
            this.cats = new Dictionary<string, Cat>();
        }

        public void Run()
        {
            var input = Console.ReadLine();
            while (input != TerminatingCommand)
            {
                var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var breed = args[0];
                var name = args[1];

                Cat cat = null;

                switch (breed)
                {
                    case "StreetExtraordinaire":
                        cat = new StreetExtraordinaire(name, int.Parse(args[2]));
                        break;
                    case "Cymric":
                        cat = new Cymric(name, double.Parse(args[2]));
                        break;
                    case "Siamese":
                        cat = new Siamese(name, int.Parse(args[2]));
                        break;
                    default:
                        break;
                }

                this.cats.Add(name, cat);
                input = Console.ReadLine();
            }

            Print();
        }

        private void Print()
        {
            var input = Console.ReadLine();
            Console.WriteLine(this.cats[input]);
        }
    }
}
