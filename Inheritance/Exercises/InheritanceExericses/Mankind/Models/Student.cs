namespace Mankind.Models
{
    using System;

    public class Student : Human
    {
        private string facultyNummber;

        private const int MinFacultyLength = 5;
        private const int MaxFacultyLength = 10;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNummber; }
            set
            {
                if (value.Length >= MinFacultyLength &&
                   value.Length <= MaxFacultyLength)
                {
                    this.facultyNummber = value;
                }
                else
                {
                    throw new ArgumentException("Invalid faculty number!");

                }

                this.facultyNummber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\nFaculty number: {this.FacultyNumber}";
        }
    }
}
