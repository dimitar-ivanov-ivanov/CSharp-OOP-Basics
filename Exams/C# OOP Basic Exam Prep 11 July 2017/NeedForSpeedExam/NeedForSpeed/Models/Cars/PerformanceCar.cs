using System.Collections.Generic;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.Horsepower += this.Horsepower * 50 / 100;
        this.Suspension -= this.Suspension * 25 / 100;
        this.addOns = new List<string>();
    }

    public override void TuneCar(int tuneIndex, string tuneAddOn)
    {
        base.TuneCar(tuneIndex, tuneAddOn);
        this.addOns.Add(tuneAddOn);
    }

    public override string ToString()
    {
        var addStr = "";

        if (this.addOns.Count == 0)
        {
            addStr = "Add-ons: None";
        }
        else
        {
            addStr = "Add-ons: " + string.Join(", ", this.addOns);
        }

        return base.ToString() + "\n" +
            addStr;
    }
}
