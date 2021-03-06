﻿using System.Linq;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override int PerformancePoints(ICar car)
    {
        return car.EnginePerformance();
    }
}
