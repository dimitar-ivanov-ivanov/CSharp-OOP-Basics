namespace PawInc.Models.Animals
{
    public class Cat : Animal
    {
        private int intelligenceCoefficient;
        public int IntelligenceCoefficient => intelligenceCoefficient;

        public Cat(string name, int age, string adoptionCenter, int intelligenceCoefficient)
            : base(name, age, adoptionCenter)
        {
            this.intelligenceCoefficient = intelligenceCoefficient;
        }
    }
}
