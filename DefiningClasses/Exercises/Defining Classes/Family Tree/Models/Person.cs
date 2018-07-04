namespace Family_Tree.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Person
    {
        private string name;
        private IList<Person> children;
        private IList<Person> parents;
        private string birthdate;

        public Person()
        {
            this.children = new List<Person>();
            this.parents = new List<Person>();
        }

        public Person(string name)
            : this()
        { }

        public Person(string name, string birthday)
            : this(name)
        {
            this.birthdate = birthday;
        }


        public string Name { get => name; set => name = value; }

        public IList<Person> Children { get => children; private set => children = value; }

        public IList<Person> Parents { get => parents; private set => parents = value; }

        public string Birthdate { get => birthdate; set => birthdate = value; }

        public Person FindChild(string childName)
        {
            return this.children.FirstOrDefault(c => c.Name == childName);
        }

        public void AddChildrenInfo(string name, string birthdate)
        {
            if (this.children.FirstOrDefault(c => c.Name == name) != null)
            {
                this.children
                    .FirstOrDefault(c => c.Name == name)
                    .Birthdate = birthdate;
                return;
            }
            if (this.children.FirstOrDefault(c => c.Birthdate == birthdate) != null)
            {
                this.children
                    .FirstOrDefault(c => c.Birthdate == birthdate)
                    .Name = name;
            }
        }


        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"{this.Name} {this.Birthdate}");
            output.AppendLine("Company:");

            output.AppendLine("Parents:");

            foreach (var parent in this.parents)
            {
                output.AppendLine($"{parent.Name} {parent.Birthdate}");
            }

            output.AppendLine("Children:");

            foreach (var child in this.children)
            {
                output.AppendLine($"{child.Name} {child.Birthdate}");
            }

            if (output.Length > 0)
            {
                output = output.Remove(output.Length - 2, 2);
            }

            return output.ToString();
        }
    }
}
