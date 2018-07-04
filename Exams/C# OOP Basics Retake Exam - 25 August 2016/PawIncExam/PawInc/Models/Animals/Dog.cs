namespace PawInc.Models.Animals
{
    public class Dog : Animal
    {
        private int amountOfCommands;
        public int AmountOfCommands => amountOfCommands;

        public Dog(string name, int age, string adoptionCenter,int amountOfCommands) 
            : base(name, age, adoptionCenter)
        {
            this.amountOfCommands = amountOfCommands;
        } 
    }
}
