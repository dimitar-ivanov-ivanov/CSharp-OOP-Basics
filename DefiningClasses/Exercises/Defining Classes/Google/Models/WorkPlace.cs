namespace Google.Models
{
    public class WorkPlace
    {
        private string name;
        private string department;
        private double salary;

        public WorkPlace(string name, string department, double salary)
        {
            this.name = name;
            this.department = department;
            this.salary = salary;
        }

        public string Name { get => name; private set => name = value; }

        public string Department { get => department; private set => department = value; }

        public double Salary { get => salary; private set => salary = value; }

        public override string ToString()
        {
            return $"{this.Name} {this.Department} {this.Salary:f2}";
        }
    }
}
