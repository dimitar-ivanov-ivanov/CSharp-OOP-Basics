namespace Vehicles_Extension.Models
{
    public class Bus : Vechile
    {
        private const double FuelIncrement = 1.4;

        public Bus(double fuelQuatity, double fuelConsumption, double tankCapacity)
          : base(fuelQuatity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            this.FuelConsumption += FuelIncrement;
            base.Drive(distance);
            this.FuelConsumption -= FuelIncrement;
        }

        public void DriveEmpty(double distance)
        {
            base.Drive(distance);
        }
    }
}
