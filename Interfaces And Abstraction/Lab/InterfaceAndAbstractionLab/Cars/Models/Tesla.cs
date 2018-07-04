namespace Cars.Models
{ 
    using Cars.Contracts;

    public class Tesla : Car, IElectricCar
    {
        private int battery;

        public Tesla(string model, string color,int battery) 
            : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery
        {
            get { return this.battery; }
            private set { this.battery = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $" with {this.battery} Batteries\n"
                + this.Start() + "\n"
                + this.Stop();
        }
    }
}
