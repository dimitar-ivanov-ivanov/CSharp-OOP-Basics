namespace Cat_Lady.Models
{
    public class Siamese : Cat
    {
        private int earSize;

        public Siamese(string name, int earSize)
            : base(name)
        {
            this.earSize = earSize;
        }

        public int EarSize { get => earSize; private set => earSize = value; }

        public override string ToString()
        {
            return base.ToString() + $" {this.earSize}";
        }
    }
}
