namespace Create__Person.Models
{
    using System;
    using System.Text;

    public abstract class Person
    {
        private string name;
        private int age;

        private const int MinLengthName = 3;

        protected Person(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(value.Length < MinLengthName)
                {
                    throw new ArgumentException($"Name's length should not be less than {MinLengthName} symbols!");
                }
                this.name = value;
            }
        }

        public virtual int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();
        }
    }
}
