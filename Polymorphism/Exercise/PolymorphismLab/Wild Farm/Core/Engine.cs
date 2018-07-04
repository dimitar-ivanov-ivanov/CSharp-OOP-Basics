
namespace Wild_Farm.Core
{
    using System;
    using System.Collections.Generic;
    using Wild_Farm.Models.Animals;
    using Wild_Farm.Models.Animals.Birds;
    using Wild_Farm.Models.Animals.Mammals;
    using Wild_Farm.Models.Animals.Mammals.Felines;
    using Wild_Farm.Models.Foods;

    public class Engine
    {
        private const string TerminatingCommand = "End";

        public void Run()
        {
            var input = Console.ReadLine();
            var animals = new List<Animal>();

            while (input != TerminatingCommand)
            {
                var animal = GetAnimal(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

                input = Console.ReadLine();
                var food = GetFood(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

                Console.WriteLine(animal.ProduceSound());

                animals.Add(animal);

                try
                {
                    animal.EatFood(food);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            Print(animals);
        }

        private void Print(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        public Animal GetAnimal(string[] args)
        {
            var animalType = args[0];
            var name = args[1];
            var weight = double.Parse(args[2]);

            switch (animalType)
            {
                case "Owl":
                    var wingSize = double.Parse(args[3]);
                    return new Owl(name, weight, wingSize);
                case "Hen":
                    wingSize = double.Parse(args[3]);
                    return new Hen(name, weight, wingSize);
                case "Mouse":
                    var livingRegion = args[3];
                    return new Mouse(name, weight, livingRegion);
                case "Dog":
                    livingRegion = args[3];
                    return new Dog(name, weight, livingRegion);
                case "Cat":
                    livingRegion = args[3];
                    var breed = args[4];
                    return new Cat(name, weight, livingRegion, breed);
                case "Tiger":
                    livingRegion = args[3];
                    breed = args[4];
                    return new Tiger(name, weight, livingRegion, breed);
                default:
                    break;
            }

            return null;

        }

        public Food GetFood(string[] args)
        {
            var name = args[0];
            var quantity = int.Parse(args[1]);

            switch (name)
            {
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default:
                    break;
            }

            return null;
        }
    }
}
