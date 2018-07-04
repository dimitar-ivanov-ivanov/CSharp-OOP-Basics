﻿namespace Animals.Models
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender = "Female") 
            : base(name, age, gender)
        {
        }

        public new string ProduceSound()
        {
            return "Miau";
        }
    }
}