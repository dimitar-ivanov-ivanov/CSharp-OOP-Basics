namespace Wild_Farm.Models.Animals.Mammals.Felines
{
    using System.Collections.Generic;

    public class Tiger : Feline
    {
        private const double AnimalWeightGain = 1;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightGain => AnimalWeightGain;

        public override IReadOnlyList<string> FoodAllowed => new List<string>()
        {
            "Meat"
        };


        public override string ProduceSound()
        {
            return $"ROAR!!!";
        }
    }
}
