namespace Wild_Farm.Models.Animals.Mammals
{
    using System.Collections.Generic;

    public class Mouse : Mammal
    {
        private const double AnimalWeightGain = 0.1;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightGain => AnimalWeightGain;

        public override IReadOnlyList<string> FoodAllowed => new List<string>()
        {
            "Vegetable",
            "Fruit"
        };

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() +
                $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
