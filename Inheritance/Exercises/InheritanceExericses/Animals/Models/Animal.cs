namespace Animals.Models
{
    using Animals.Contracts;
    using System;

    public abstract class Animal : ISoundProducable
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get { return this.gender; }
            private set
            {
                if (string.IsNullOrEmpty(value) ||
                 string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name}\n" +
                   $"{this.Name} {this.Age} {this.Gender}\n" +
                   this.ProduceSound();
        }
    }
}
