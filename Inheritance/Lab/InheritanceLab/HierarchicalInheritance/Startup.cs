﻿namespace HierarchicalInheritance
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var dog = new Dog();
            dog.Eat();
            dog.Bark();

            var cat = new Cat();
            cat.Eat();
            cat.Meow();
        }
    }
}