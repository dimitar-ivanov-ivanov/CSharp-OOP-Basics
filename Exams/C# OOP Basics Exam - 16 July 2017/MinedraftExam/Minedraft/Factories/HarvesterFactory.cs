using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> args)
    {
        var type = args[0];
        var id = args[1];
        var oreOutput = double.Parse(args[2]);
        var energyRequirement = double.Parse(args[3]);

        if (type == "Hammer")
        {
            return new HammerHarvester(id, oreOutput, energyRequirement);
        }
        else if (type == "Sonic")
        {
            var sonicFactor = int.Parse(args[4]);
            return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
        }

        throw new ArgumentException(OutputMessages.InvalidHarverster, type);
    }
}
