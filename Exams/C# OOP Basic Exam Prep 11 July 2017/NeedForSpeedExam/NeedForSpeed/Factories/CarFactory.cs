using System;
using System.Linq;
using System.Reflection;

public class CarFactory : ICarFactory
{
    private const string Suffix = "Car";

    public ICar CreateCar(string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        var typeToActivate = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == type + Suffix);

        var car = (ICar)Activator.CreateInstance(typeToActivate,
            brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);

        return car;
    }
}
