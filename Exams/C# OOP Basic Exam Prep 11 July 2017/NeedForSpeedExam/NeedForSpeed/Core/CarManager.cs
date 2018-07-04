using System;
using System.Collections.Generic;

public class CarManager : ICarManager
{
    private Dictionary<int, IRace> races;
    private Dictionary<int, ICar> cars;
    private Garage garage;
    private ICarFactory carFactory;
    private IRaceFactory raceFactory;

    public CarManager()
    {
        this.garage = new Garage();
        this.races = new Dictionary<int, IRace>();
        this.cars = new Dictionary<int, ICar>();
        this.carFactory = new CarFactory();
        this.raceFactory = new RaceFactory();
    }

    public string Check(int id)
    {
        return this.cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        var race = this.raceFactory.CreateRace(type, length, route, prizePool);

        if (!this.races.ContainsKey(id))
        {
            this.races.Add(id, race);
        }
    }

    public void Park(int id)
    {
        this.garage.ParkCar(this.cars[id]);
    }

    public void Participate(int carId, int raceId)
    {
        this.races[raceId].AddCar(this.cars[carId]);
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        var car = this.carFactory.CreateCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);

        if (!this.cars.ContainsKey(id))
        {
            this.cars.Add(id, car);
        }
    }

    public string Start(int id)
    {
        try
        {
            var res = this.races[id].Start();
            this.races.Remove(id);
            return res;
        }
        catch(ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        garage.TuneCars(tuneIndex, addOn);
    }

    public void Unpark(int id)
    {
        garage.UnParkCar(this.cars[id]);
    }
}
