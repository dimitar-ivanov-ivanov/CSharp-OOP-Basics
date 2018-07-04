namespace Vehicles_Extension.Models
{
    using System;
    using Vehicles_Extension.Contracts;

    public abstract class Vechile : IVechile
    {
        private double fuelQuatity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vechile(double fuelQuatity, double fuelConsumption,
            double tankCapacity)
        {
            this.TankCapacity = tankCapacity; //NB Tank capacity before fuelQuantity
            this.FuelQuantity = fuelQuatity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return this.fuelQuatity; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                if (value > tankCapacity)
                {
                    throw new ArgumentException($"Cannot fit {value} fuel in the tank");
                }
                this.fuelQuatity = value;
            }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            protected set { this.fuelConsumption = value; }
        }

        public double TankCapacity
        {
            get { return this.tankCapacity; }
            protected set { this.tankCapacity = value; }
        }

        public virtual void Drive(double distance)
        {
            var fuelNeeded = this.FuelConsumption * distance;
            if (fuelNeeded > this.FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            else
            {
                this.FuelQuantity -= fuelNeeded;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
