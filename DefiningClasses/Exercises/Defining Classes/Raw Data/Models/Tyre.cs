namespace Raw_Data.Models
{
    public class Tyre
    {
        private double pressure;
        private int age;

        public Tyre(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure { get => pressure; private set => pressure = value; }

        public int Age { get => age; private set => age = value; }
    }
}
