﻿public class ShowCar : Car
{
    private int stars;

    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.stars = 0;
    }

    public override void TuneCar(int tuneIndex, string tuneAddOn)
    {
        base.TuneCar(tuneIndex, tuneAddOn);
        this.stars += tuneIndex;
    }

    public override string ToString()
    {
        return base.ToString()  + "\n" + 
            $"{stars} *";
    }
}
