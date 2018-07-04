namespace Vehicles_Extension.Models
{
    using System;

    public class Truck : Vechile
    {
        private const double FuelIncrement = 1.6;

        public Truck(double fuelQuatity, double fuelConsumption, double tankCapacity)
           : base(fuelQuatity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += FuelIncrement;
        }

        public override void Refuel(double liters)
        {
            var toRefuel = liters * 95 / 100d;

            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + toRefuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += toRefuel;
        }
    }
}
