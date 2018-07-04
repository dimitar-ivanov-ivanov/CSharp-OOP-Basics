namespace Vehicles.Models
{
    public class Car : Vechile
    {
        private const double FuelIncrement = 0.9;

        public Car(double fuelQuatity, double fuelConsumption)
            : base(fuelQuatity, fuelConsumption)
        {
            this.FuelConsumption += FuelIncrement;
        }
    }
}
