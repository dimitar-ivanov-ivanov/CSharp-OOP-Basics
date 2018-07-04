namespace Wild_Farm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wild_Farm.Models.Foods;

    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        private const int AnimalWeightGain = 1;

        public Animal(string name,double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public double Weight
        {
            get { return this.weight; }
            private set { this.weight = value; }
        }

        public int FoodEaten
        {
            get { return this.foodEaten; }
            private set { this.foodEaten = value; }
        }

        public abstract string ProduceSound();

        public virtual double WeightGain => AnimalWeightGain;

        public virtual IReadOnlyList<string> FoodAllowed => new List<string>()
        {
            "Vegetable",
            "Fruit",
            "Meat",
            "Seeds"
        };

        public void EatFood(Food food)
        {
            var foodType = food.GetType().Name;
            if (!FoodAllowed.Contains(food.GetType().Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }

            this.Weight += WeightGain * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}