﻿namespace Food_Shortage.Models
{
    using Food_Shortage.Contracts;

    public class Rebel : IRebel
    {
        private string name;
        private int age;
        private string group;
        private int food;
        private const int FoodToBuy = 5;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            private set { this.age = value; }
        }

        public string Group
        {
            get { return this.group; }
            private set { this.group = value; }
        }

        public int Food
        {
            get { return this.food; }
            private set { this.food = value; }
        }

        public void BuyFood()
        {
            this.Food += FoodToBuy;
        }
    }
}
