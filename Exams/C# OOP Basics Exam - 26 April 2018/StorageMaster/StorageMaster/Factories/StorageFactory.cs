using StorageMaster.Constants;
using StorageMaster.Models.Storages;
using System;

public class StorageFactory
{
    public Storage CreateStorage(string type, string name)
    {
        switch (type)
        {
            case "AutomatedWarehouse":
                return new AutomatedWarehouse(name);
            case "DistributionCenter":
                return new DistributionCenter(name);
            case "Warehouse":
                return new Warehouse(name);
            default:
                break;
        }

        throw new InvalidOperationException(string.Format(OutputMessages.InvalidType, "storage"));
    }
}