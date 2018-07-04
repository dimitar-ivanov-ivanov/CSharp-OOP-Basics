namespace P01_RawData
{
    public class Tyre
    {
        private int age;
        private double pressure;

        public Tyre(double pressure, int age)
        {
            this.pressure = pressure;
            this.age = age;
        }

        public int Age { get => age; set => age = value; }

        public double Pressure { get => pressure; set => pressure = value; }
    }
}
