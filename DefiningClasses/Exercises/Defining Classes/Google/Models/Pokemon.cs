namespace Google.Models
{
    public class Pokemon
    {
        private string name;
        private string type;

        public Pokemon(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public string Name { get => name; private set => name = value; }
        public string Type { get => type; private set => type = value; }

        public override string ToString()
        {
            return $"{this.Name} {this.Type}";
        }
    }
}
