namespace Border_Control.Models
{
    using Border_Control.Contracts;

    public class Citizen : ICitizen
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            private set { this.age = value; }
        }

        public string Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }
    }
}
