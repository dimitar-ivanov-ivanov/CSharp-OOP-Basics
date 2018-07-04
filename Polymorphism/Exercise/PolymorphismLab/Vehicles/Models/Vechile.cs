namespace Vehicles.Models
{
    using System;
    using Vehicles.Contracts;

    public abstract class Vechile : IVechile
    {
        private double fuelQuatity;
        private double fuelConsumption;

        public Vechile(double fuelQuatity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuatity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return this.fuelQuatity; }
            protected set { this.fuelQuatity = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            protected set { this.fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            var fuelNeeded = this.FuelConsumption * distance;
            if (fuelNeeded > this.FuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
            else
            {
                this.FuelQuantity -= fuelNeeded;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
