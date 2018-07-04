namespace PawInc.Models.Centers
{
    using PawInc.Models.Animals;
    using System.Collections.Generic;

    public abstract class Center
    {
        private string name;
        private List<Animal> animals;

        public List<Animal> Animals
        {
            get { return this.animals; }
            set { this.animals = value; }
        }

        public Center(string name)
        {
            this.animals = new List<Animal>();
            this.name = name;
        }
    }
}
