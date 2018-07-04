using System.Collections.Generic;

public interface IGarage
{
    IReadOnlyList<ICar> ParkedCars   { get; }

    void ParkCar(ICar car);

    void UnParkCar(ICar car);

    void TuneCars(int tuneIndex, string tuneAddOn);
}