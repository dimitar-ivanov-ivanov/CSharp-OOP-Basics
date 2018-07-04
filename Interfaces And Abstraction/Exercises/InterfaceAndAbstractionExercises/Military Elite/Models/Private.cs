namespace Military_Elite.Models
{
    using Military_Elite.Contracts;

    public class Private : Soldier, IPrivate
    {
        private double salary;

        public Private(int id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName)
        {
            this.salary = salary;
        }

        public double Salary
        {
            get { return this.salary; }
            private set { this.salary = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.salary:f2}";
        }
    }
}
