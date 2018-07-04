namespace Military_Elite.Models
{
    using Military_Elite.Contracts;

    public class Spy : Soldier, ISpy
    {
        private int codeNumber;

        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.codeNumber = codeNumber;
        }

        public int CodeNumber
        {
            get { return this.codeNumber; }
            private set { this.codeNumber = value; }
        }

        public override string ToString()
        {
            return base.ToString()
                + $"\nCode Number: {this.codeNumber}";
        }
    }
}
