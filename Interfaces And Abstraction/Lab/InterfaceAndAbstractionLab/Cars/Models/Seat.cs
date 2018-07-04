namespace Cars.Models
{
    public class Seat : Car
    {
        public Seat(string model, string color) :
            base(model, color)
        {
        }

        public override string ToString()
        {
            return base.ToString() + "\n" + this.Start() +
                "\n" + this.Stop();
        }
    }
}
