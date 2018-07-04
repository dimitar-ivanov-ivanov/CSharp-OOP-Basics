namespace Vehicles.Models
{
    public class Truck : Vechile
    {
        private const double FuelIncrement = 1.6;

        public Truck(double fuelQuatity, double fuelConsumption) 
            : base(fuelQuatity, fuelConsumption)
        {
            this.FuelConsumption += FuelIncrement;
        }

        public override void Refuel(double liters)
        {
            var toRefuel = liters * 95 / 100d;
            this.FuelQuantity += toRefuel;
        }
    }
}
