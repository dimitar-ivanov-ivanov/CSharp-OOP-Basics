namespace Vehicles_Extension.Contracts
{
    public interface IVechile
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double TankCapacity { get; }

        void Refuel(double liters);

        void Drive(double distance);
    }
}
