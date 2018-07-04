using StorageMaster.Constants;
using StorageMaster.Models.Products;
using System;

public class ProductFactory
{
    public Product CreateProduct(string type, double price)
    {
        switch (type)
        {
            case "Gpu":
                return new Gpu(price);
            case "HardDrive":
                return new HardDrive(price);
            case "Ram":
                return new Ram(price);
            case "SolidStateDrive":
                return new SolidStateDrive(price);
            default:
                break;
        }

        throw new InvalidOperationException(string.Format(OutputMessages.InvalidType, "product"));
    }
}