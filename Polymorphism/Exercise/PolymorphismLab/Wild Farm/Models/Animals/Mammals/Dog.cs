namespace Wild_Farm.Models.Animals.Mammals
{
    using System.Collections.Generic;

    public class Dog : Mammal
    {
        private const double AnimalWeightGain = 0.4;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightGain => AnimalWeightGain;

        public override IReadOnlyList<string> FoodAllowed => new List<string>()
        {
            "Meat"
        };

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() +
                $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
