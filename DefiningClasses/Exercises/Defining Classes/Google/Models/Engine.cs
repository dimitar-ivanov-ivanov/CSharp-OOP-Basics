namespace Google.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Engine
    {
        private Dictionary<string, Person> people;
        private MethodInfo[] methods;
        private const string TerminatingCommand = "End";
        private const string MethodNamePrefix = "Create";

        public Engine()
        {
            this.people = new Dictionary<string, Person>();
            this.methods = this
                .GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Static | BindingFlags.Instance);
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != TerminatingCommand)
            {
                var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = args[0];
                var methodName = MethodNamePrefix + args[1];

                if (!people.ContainsKey(name))
                {
                    this.people.Add(name, new Person(name));
                }

                var methodToInvoke = this.methods
                      .FirstOrDefault
                      (x => x.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                var methodParams = args.Skip(2).ToArray();

                methodToInvoke.Invoke(this, new object[] { name, methodParams });

                input = Console.ReadLine();
            }
        }

        public void PrintPerson(string name)
        {
            Console.WriteLine(people[name]);
        }

        private void CreateCompany(string name, string[] args)
        {
            var companyName = args[0];
            var department = args[1];
            var salary = double.Parse(args[2]);

            var workPlace = new WorkPlace(companyName, department, salary);

            this.people[name].WorkPlace = workPlace;
        }

        private void CreatePokemon(string name, string[] args)
        {
            var pokemonName = args[0];
            var pokemonType = args[1];
            var pokemon = new Pokemon(pokemonName, pokemonType);

            this.people[name].Pokemons.Add(pokemon);
        }

        private void CreateParents(string name, string[] args)
        {
            var parentName = args[0];
            var parentBirthday = args[1];

            var parent = new Person(parentName, parentBirthday);

            if (!this.people.ContainsKey(parentName))
            {
                this.people.Add(parentName, parent);
            }

            this.people[name].Parents.Add(parent);
            //this.people[parentName].Children.Add(this.people[name]);
        }

        private void CreateChildren(string name, string[] args)
        {
            var childrenName = args[0];
            var childrenBirthday = args[1];

            var child = new Person(childrenName, childrenBirthday);

            if (!this.people.ContainsKey(childrenName))
            {
                this.people.Add(childrenName, child);
            }

            this.people[name].Children.Add(child);
            //this.people[childrenName].Parents.Add(this.people[name]);
        }

        private void CreateCar(string name, string[] args)
        {
            var carModel = args[0];
            var carSpeed = int.Parse(args[1]);
            var car = new Car(carModel, carSpeed);

            this.people[name].Car = car;
        }
    }
}
