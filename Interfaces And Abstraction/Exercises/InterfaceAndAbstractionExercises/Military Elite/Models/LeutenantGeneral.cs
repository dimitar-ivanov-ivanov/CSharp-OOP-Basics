namespace Military_Elite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Military_Elite.Contracts;

    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        private IList<IPrivate> privates;

        public LeutenantGeneral(int id, string firstName, 
            string lastName, double salary,IList<IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public IList<IPrivate> Privates
        {
            get { return this.privates; }
            private set { this.privates = value; }
        }

        public override string ToString()
        {
            var output = new StringBuilder("\n");
            output.AppendLine("Privates:");

            foreach (var privateSoldier in this.privates)
            {
                output.AppendLine("  " + privateSoldier.ToString());
            }

            output = output.Remove(output.Length - 2, 2);

            return base.ToString() + output.ToString();
        }
    }
}
