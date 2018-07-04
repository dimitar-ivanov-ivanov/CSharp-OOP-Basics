namespace Wild_Farm.Models.Animals.Mammals.Felines
{
    using System.Collections.Generic;

    public class Cat : Feline
    {
        private const double AnimalWeightGain = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightGain => AnimalWeightGain;

        public override IReadOnlyList<string> FoodAllowed => new List<string>()
        {
            "Vegetable",
            "Meat"
        };

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
