using System;

public abstract class Provider : Unit
{
    private const double MaxEnergyOutput = 10000;

    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public override string Type
    {
        get
        {
            var name = this.GetType().Name;
            return name.Substring(0, name.Length - "Provider".Length);
        }
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value > 0 && value < MaxEnergyOutput)
            {
                this.energyOutput = value;
            }
            else
            {
                throw new ArgumentException(string.Format(OutputMessages.NotRegistered, "Provider", "EnergyOutput"));
            }
        }
    }

    public override string ToString()
    {
        return $"{this.Type} Provider - {this.Id}\n" +
               $"Energy Output: {this.EnergyOutput}";
    }
}

