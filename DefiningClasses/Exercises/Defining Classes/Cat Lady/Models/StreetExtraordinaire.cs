namespace Cat_Lady.Models
{
    public class StreetExtraordinaire : Cat
    {
        private int decibelsOfMeows;

        public StreetExtraordinaire(string name,int decibelsOfMeows)
            : base(name)
        {
            this.decibelsOfMeows = decibelsOfMeows;
        }

        public int DecibelsOfMeows { get => decibelsOfMeows; private set => decibelsOfMeows = value; }

        public override string ToString()
        {
            return base.ToString() + $" {this.decibelsOfMeows}";
        }
    }
}
