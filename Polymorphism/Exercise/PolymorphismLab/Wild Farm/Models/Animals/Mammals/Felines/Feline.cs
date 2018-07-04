namespace Wild_Farm.Models.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal
    {
        private string breed;

        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.breed = breed;
        }

        public string Breed
        {
            get { return this.breed; }
            private set { this.breed = value; }
        }

        public override string ToString()
        {
            return base.ToString()
                + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
