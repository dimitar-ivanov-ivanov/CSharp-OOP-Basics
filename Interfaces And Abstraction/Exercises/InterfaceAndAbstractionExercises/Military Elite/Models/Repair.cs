namespace Military_Elite.Models
{
    using Military_Elite.Contracts;

    public class Repair : IRepair
    {
        private string partName;
        private int hoursWorked;

        public Repair(string partName, int hoursWorked)
        {
            this.partName = partName;
            this.hoursWorked = hoursWorked;
        }

        public string PartName
        {
            get { return this.partName; }
            private set { this.partName = value; }
        }

        public int HoursWorked
        {
            get { return this.hoursWorked; }
            private set { this.hoursWorked = value; }
        }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
