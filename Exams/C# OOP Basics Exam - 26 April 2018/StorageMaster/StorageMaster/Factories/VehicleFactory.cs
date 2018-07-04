using StorageMaster.Constants;
using StorageMaster.Models.Vechiles;
using System;

public class VehicleFactory
{
    public Vehicle CreateVehicle(string type)
    {
        switch (type)
        {
            case "Semi":
                return new Semi();
            case "Truck":
                return new Truck();
            case "Van":
                return new Van();
            default:
                break;
        }

        throw new InvalidOperationException(string.Format(OutputMessages.InvalidType, "vehicle"));
    }
}
