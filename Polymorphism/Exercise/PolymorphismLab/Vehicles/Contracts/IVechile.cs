namespace Vehicles.Contracts
{
    public interface IVechile
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        void Refuel(double liters);

        void Drive(double distance);
    }
}
