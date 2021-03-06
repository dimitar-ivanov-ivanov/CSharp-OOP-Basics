﻿using System.Linq;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override int PerformancePoints(ICar car)
    {
        return car.OverallPerformance();
    }
}