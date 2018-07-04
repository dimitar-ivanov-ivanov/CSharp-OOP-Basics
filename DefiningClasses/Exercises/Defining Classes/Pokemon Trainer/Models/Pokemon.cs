namespace Pokemon_Trainer.Models
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public Pokemon(string name, string element, int health)
        {
            this.name = name;
            this.element = element;
            this.health = health;
        }

        public string Name { get => name; private set => name = value; }

        public string Element { get => element; private set => element = value; }

        public int Health { get => health; set => health = value; }
    }
}
