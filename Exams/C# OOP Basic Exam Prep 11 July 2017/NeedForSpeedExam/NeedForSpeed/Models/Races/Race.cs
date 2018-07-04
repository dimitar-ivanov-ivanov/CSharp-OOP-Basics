using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race : IRace
{
    private readonly List<ICar> cars;

    protected Race(int length, string route, int prizePool)
    {
        Length = length;
        Route = route;
        PrizePool = prizePool;
        this.cars = new List<ICar>();
    }

    public int Length { get; }

    public string Route { get; }

    public int PrizePool { get; }

    public IReadOnlyList<ICar> Cars => cars;


    public void AddCar(ICar car)
    {
        if (!car.InGarage)
        {
            car.RacingCount++;
            this.cars.Add(car);
        }
    }

    public abstract int PerformancePoints(ICar car);

    public string Start()
    {
        if (this.cars.Count == 0)
        {
            throw new ArgumentException("Cannot start the race with zero participants");
        }

        var cars = this.cars
            .OrderByDescending(x => PerformancePoints(x))
            .Take(3)
            .ToArray();

        var percentages = new int[] { 50, 30, 20 };

        var builder = new StringBuilder();
        builder.AppendLine($"{this.Route} - {this.Length}");

        for (int i = 0; i < cars.Length; i++)
        {
            var car = cars[i];
            var performancePoints = PerformancePoints(car);
            var moneyWon = this.PrizePool * percentages[i] / 100;
            builder.AppendLine($"{i + 1}. {car.Brand} {car.Model} {performancePoints}PP - ${moneyWon}");
        }

        foreach (var car in this.cars)
        {
            car.RacingCount--;
        }

        return builder.ToString().TrimEnd();
    }
}
