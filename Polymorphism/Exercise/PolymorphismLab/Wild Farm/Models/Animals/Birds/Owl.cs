namespace Wild_Farm.Models.Animals.Birds
{
    using System.Collections.Generic;

    public class Owl : Bird
    {
        private const double AnimalWeightGain = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightGain => AnimalWeightGain;

        public override IReadOnlyList<string> FoodAllowed => new List<string>()
        {
            "Meat"
        };

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
