public abstract class Car : ICar
{
    protected Car(string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        Brand = brand;
        Model = model;
        YearOfProduction = yearOfProduction;
        Horsepower = horsepower;
        Acceleration = acceleration;
        Suspension = suspension;
        Durability = durability;
        this.InGarage = false;
        this.RacingCount = 0;
    }

    public string Brand { get; }

    public string Model { get; }

    public int YearOfProduction { get; }

    public int Horsepower { get; protected set; }

    public int Acceleration { get; }

    public int Suspension { get; protected set; }

    public int Durability { get; }

    public bool InGarage { get; set; }

    public int RacingCount { get; set; }

    public int OverallPerformance()
    {
        return EnginePerformance() + SuspensionPerformance();
    }

    public int EnginePerformance()
    {
        return (this.Horsepower / this.Acceleration);
    }

    public int SuspensionPerformance()
    {
        return (this.Suspension + this.Durability);
    }

    public override string ToString()
    {
        return $"{this.Brand} {this.Model} {this.YearOfProduction}\n" +
               $"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s\n" +
               $"{this.Suspension} Suspension force, {this.Durability} Durability";
    }

    public virtual void TuneCar(int tuneIndex, string tuneAddOn)
    {
        this.Horsepower += tuneIndex;
        this.Suspension += tuneIndex / 2;
    }
}
