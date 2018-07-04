namespace Vehicles_Extension.Models
{
    public class Car : Vechile
    {
        private const double FuelIncrement = 0.9;

        public Car(double fuelQuatity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuatity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += FuelIncrement;
        }
    }
}
