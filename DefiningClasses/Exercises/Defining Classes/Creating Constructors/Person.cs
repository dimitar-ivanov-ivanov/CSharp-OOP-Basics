﻿namespace Creating_Constructor
{
    public class Person
    {
        private string name;
        private int age;

        public Person()
            : this(1)
        {
        }

        public Person(int age)
            : this("No name", age)
        {
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get => name; set => name = value; }

        public int Age { get => age; set => age = value; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}