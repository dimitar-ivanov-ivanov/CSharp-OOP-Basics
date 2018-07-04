namespace Company_Roster.Models
{
    public class Employee
    {
        private string name;
        private double salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public string Name { get => name; private set => name = value; }

        public double Salary { get => salary; private set => salary = value; }

        public string Position { get => position; private set => position = value; }

        public string Department { get => department; private set => department = value; }

        public string Email { get => email; set => email = value; }

        public int Age { get => age; set => age = value; }

        public Employee(string name, double salary, string position,
            string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = "n/a";
            this.age = -1;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Salary:f2} {this.Email} {this.Age}";
        }
    }
}
