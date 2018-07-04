namespace Google.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string name;
        private WorkPlace workPlace;
        private Car car;
        private IList<Pokemon> pokemons;
        private IList<Person> children;
        private IList<Person> parents;
        private string birthday;

        public Person(string name)
        {
            this.name = name;
            this.pokemons = new List<Pokemon>();
            this.children = new List<Person>();
            this.parents = new List<Person>();
        }

        public Person(string name,string birthday)
            :this(name)
        {
            this.birthday = birthday;
        }

        public string Name { get => name; private set => name = value; }

        public WorkPlace WorkPlace { get => workPlace; set => workPlace = value; }

        public Car Car { get => car; set => car = value; }
        
        public IList<Pokemon> Pokemons { get => pokemons; private set => pokemons = value; }

        public IList<Person> Children { get => children; private set => children = value; }

        public IList<Person> Parents { get => parents; private set => parents = value; }

        public string Birthday { get => birthday; private set => birthday = value; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(this.Name);
            output.AppendLine("Company:");

            if(this.WorkPlace  != null)
            {
                output.AppendLine(this.WorkPlace.ToString());
            }

            output.AppendLine("Car:");

            if(this.Car != null)
            {
                output.AppendLine(this.Car.ToString());
            }

            output.AppendLine("Pokemon:");

            foreach (var pokemon in this.pokemons)
            {
                output.AppendLine(pokemon.ToString());
            }

            output.AppendLine("Parents:");

            foreach (var parent in this.parents)
            {
                output.AppendLine($"{parent.Name} {parent.Birthday}");
            }

            output.AppendLine("Children:");

            foreach (var child in this.children)
            {
                output.AppendLine($"{child.Name} {child.Birthday}");
            }

            if(output.Length > 0)
            {
                output = output.Remove(output.Length - 2, 2);
            }

            return output.ToString();
        }
    }
}
