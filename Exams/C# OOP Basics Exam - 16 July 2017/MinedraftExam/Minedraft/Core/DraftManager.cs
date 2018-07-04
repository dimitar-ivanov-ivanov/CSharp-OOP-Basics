using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    private List<Provider> providers;
    private List<Harvester> harvesters;

    private double totalEnergyStored;
    private double totalMinedOre;

    private string mode;

    public DraftManager()
    {
        this.providers = new List<Provider>();
        this.harvesters = new List<Harvester>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();

        this.mode = "Full";
        this.totalEnergyStored = 0d;
        this.totalMinedOre = 0d;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = this.harvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(harvester);

            return string.Format(OutputMessages.RegisteredHarvester, harvester.Type, harvester.Id);
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = this.providerFactory.CreateProvider(arguments);
            this.providers.Add(provider);

            return string.Format(OutputMessages.RegisteredProvider, provider.Type, provider.Id);
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string Day()
    {
        var dayEnergyProvided = providers.Sum(p => p.EnergyOutput);
        this.totalEnergyStored += dayEnergyProvided;
        var dayEnergyRequired = 0d;
        var dayMinedOre = 0d;

        switch (mode)
        {
            case "Full":
                dayEnergyRequired = this.harvesters.Sum(x => x.EnergyRequirement);
                dayMinedOre = this.harvesters.Sum(x => x.OreOutput);
                break;
            case "Half":
                dayEnergyRequired = this.harvesters.Sum(x => x.EnergyRequirement * 0.6);
                dayMinedOre = this.harvesters.Sum(x => x.OreOutput * 0.5);
                break;
            default:
                break;
        }

        if (totalEnergyStored >= dayEnergyRequired)
        {
            totalEnergyStored -= dayEnergyRequired;
            totalMinedOre += dayMinedOre;
        }
        else
        {
            dayMinedOre = 0;
        }

        return "A day has passed.\n" +
               $"Energy Provided: {dayEnergyProvided}\n" +
               $"Plumbus Ore Mined: {dayMinedOre}";
    }

    public string Mode(List<string> arguments)
    {
        var mode = arguments[0];
        return string.Format(OutputMessages.ChangedMode, mode);
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var unit = (Unit)this.harvesters.FirstOrDefault(x => x.Id == id) ??
                   this.providers.FirstOrDefault(x => x.Id == id);

        if (unit == null)
        {
            return string.Format(OutputMessages.NoElementFound, id);
        }

        return unit.ToString();
    }

    public string ShutDown()
    {
        return "System Shutdown\n" +
               $"Total Energy Stored: {totalEnergyStored}\n" +
               $"Total Mined Plumbus Ore: {totalMinedOre}";
    }
}

