namespace Wild_Farm.Models.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;   
        }

        public string LivingRegion
        {
            get { return this.livingRegion; }
            private set { this.livingRegion = value; }
        }     
    }
}
