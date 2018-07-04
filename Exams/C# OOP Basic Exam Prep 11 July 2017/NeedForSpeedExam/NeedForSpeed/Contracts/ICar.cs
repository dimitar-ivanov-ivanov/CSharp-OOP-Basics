public interface ICar
{
    string Brand { get; }

    string Model { get; }

    int YearOfProduction { get; }

    int Horsepower { get; }

    int Acceleration { get; }

    int Suspension { get; }

    int Durability { get; }

    bool InGarage { get; set; }

    int RacingCount { get; set; }

    void TuneCar(int tuneIndex, string tuneAddOn);

    int OverallPerformance();

    int EnginePerformance();

    int SuspensionPerformance();

}

