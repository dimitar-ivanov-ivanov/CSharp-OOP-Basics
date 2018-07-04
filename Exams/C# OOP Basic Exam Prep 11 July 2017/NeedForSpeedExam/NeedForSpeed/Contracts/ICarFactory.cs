public interface ICarFactory
{
    ICar CreateCar(string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability);
}
