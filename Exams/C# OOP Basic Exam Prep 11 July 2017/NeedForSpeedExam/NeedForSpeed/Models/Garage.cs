using System.Collections.Generic;

public class Garage : IGarage
{
    private readonly List<ICar> parkedCars;

    public Garage()
    {
        this.parkedCars = new List<ICar>();
    }

    public IReadOnlyList<ICar> ParkedCars => parkedCars;

    public void ParkCar(ICar car)
    {
        if (car.RacingCount == 0)
        {
            car.InGarage = true;
            this.parkedCars.Add(car);
        }
    }

    public void TuneCars(int tuneIndex, string tuneAddOn)
    {
        foreach (var car in this.parkedCars)
        {
            car.TuneCar(tuneIndex, tuneAddOn);
        }
    }

    public void UnParkCar(ICar car)
    {
        car.InGarage = false;
        this.parkedCars.Remove(car);
    }
}