namespace Create__Person.Models
{
    using System;

    public class Child : Person
    {
        private const int MaxChildAge = 15;

        public Child(string name, int age)
            : base(name, age)
        {
        }

        public override int Age
        {
            get { return base.Age; }
            set
            {
                if (value > MaxChildAge)
                {
                    throw new ArgumentException($"Child's age must be less than {MaxChildAge}!");
                }
                base.Age = value;
            }
        }
    }
}
