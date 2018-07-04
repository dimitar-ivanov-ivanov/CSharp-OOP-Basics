namespace Military_Elite.Models
{
    using System;
    using Military_Elite.Contracts;
    using Military_Elite.Enums;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private CorpsType corps;

        public SpecialisedSoldier(int id, string firstName, string lastName,
            double salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.corps = GetValidCorps(corps);
        }

        private CorpsType GetValidCorps(string corps)
        {
            CorpsType parsedCorps = CorpsType.Marines;

            if (!Enum.TryParse(corps, out parsedCorps))
            {
                throw new ArgumentException();
            }

            return parsedCorps;
        }

        public CorpsType Corps
        {
            get { return this.corps; }
            private set { this.corps = value; }
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\nCorps: {this.corps}";
        }
    }
}
