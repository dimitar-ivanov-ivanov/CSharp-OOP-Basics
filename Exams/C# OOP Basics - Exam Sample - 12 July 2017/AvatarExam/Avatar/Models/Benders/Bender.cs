public abstract class Bender
{
    protected Bender(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public string Name { get; }

    public int Power { get; }

    public abstract double GetTotalPower();
}
