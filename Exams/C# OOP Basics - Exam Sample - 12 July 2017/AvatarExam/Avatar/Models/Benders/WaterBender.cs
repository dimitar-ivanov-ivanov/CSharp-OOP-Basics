﻿public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity)
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity { get; }

    public override double GetTotalPower()
    {
        return this.Power * this.WaterClarity;
    }

    public override string ToString()
    {
        return $"Water Bender: {this.Name}, Power: {this.Power}, Water Clarity: {this.WaterClarity:f2}";
    }
}
