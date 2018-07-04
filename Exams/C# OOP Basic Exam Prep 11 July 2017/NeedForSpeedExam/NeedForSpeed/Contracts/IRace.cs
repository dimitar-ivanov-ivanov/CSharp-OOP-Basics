using System.Collections.Generic;

public interface IRace
{
    int Length { get; }

    string Route { get; }

    int PrizePool { get; }

    IReadOnlyList<ICar> Cars { get; }

    void AddCar(ICar car);

    string Start();

    int PerformancePoints(ICar car);
}
