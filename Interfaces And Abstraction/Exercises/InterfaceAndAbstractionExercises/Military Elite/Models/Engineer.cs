namespace Military_Elite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Military_Elite.Contracts;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private IList<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName,
            double salary, string corps,IList<IRepair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }

        public IList<IRepair> Repairs
        {
            get { return this.repairs; }
            private set { this.repairs = value; }
        }

        public override string ToString()
        {
            var output = new StringBuilder("\n");
            output.AppendLine("Repairs:");

            foreach (var repair in this.repairs)
            {
                output.AppendLine("  " + repair.ToString());
            }

            output = output.Remove(output.Length - 2, 2);

            return base.ToString() +  output.ToString();
        }
    }
}
