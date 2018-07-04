namespace Mankind.Models
{
    using System;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        private const int FirstNameMinLength = 4;
        private const int LastNameMinLength = 3;

        protected Human(string firstName, string lastName)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value.Length < FirstNameMinLength)
                {
                    throw new ArgumentException($"Expected length at least {FirstNameMinLength} symbols! Argument: firstName");
                }

                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length < LastNameMinLength)
                {
                    throw new ArgumentException($"Expected length at least {LastNameMinLength} symbols! Argument: lastName ");
                }

                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return $"First Name: {this.FirstName}" +
                   $"\nLast Name: {this.LastName}";
        }
    }
}
