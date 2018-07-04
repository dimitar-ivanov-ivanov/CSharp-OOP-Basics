namespace Wild_Farm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double AnimalWeightGain = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightGain => AnimalWeightGain;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
