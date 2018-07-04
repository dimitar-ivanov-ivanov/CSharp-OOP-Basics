namespace Cat_Lady.Models
{
    public abstract class Cat
    {
        private string name;

        public Cat(string name)
        {
            this.name = name;
        }

        public string Name { get => name; private set => name = value; }

        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Name}";
        }
    }
}
