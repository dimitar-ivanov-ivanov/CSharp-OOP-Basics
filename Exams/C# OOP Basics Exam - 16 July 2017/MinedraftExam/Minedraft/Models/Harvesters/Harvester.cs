using System;

public abstract class Harvester : Unit
{
    private const double MaxEnergyRequirement = 20000;

    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public override string Type
    {
        get
        {
            var name = this.GetType().Name;
            return name.Substring(0, name.Length - "Harvester".Length);
        }
    }

    public double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value >= 0)
            {
                this.oreOutput = value;
            }
            else
            {
                throw new ArgumentException(string.Format(OutputMessages.NotRegistered, "Harvester", "OreOutput"));
            }
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value >= 0 && value <= MaxEnergyRequirement)
            {
                this.energyRequirement = value;
            }
            else
            {
                throw new ArgumentException(string.Format(OutputMessages.NotRegistered, "Harvester", "EnergyRequirement"));
            }
        }
    }

    public override string ToString()
    {
        return $"{this.Type} Harvester - {this.Id}\n" +
               $"Ore Output: {this.OreOutput}\n" +  
               $"Energy Requirement: {this.EnergyRequirement}";
    }
}

