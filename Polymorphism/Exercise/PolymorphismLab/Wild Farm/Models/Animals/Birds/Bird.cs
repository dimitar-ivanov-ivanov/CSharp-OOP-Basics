namespace Wild_Farm.Models.Animals.Birds
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight,double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }
        
        public double WingSize
        {
            get { return this.wingSize; }
            private set { this.wingSize = value; }
        }

        public override string ToString()
        {
            return base.ToString() + 
                $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
