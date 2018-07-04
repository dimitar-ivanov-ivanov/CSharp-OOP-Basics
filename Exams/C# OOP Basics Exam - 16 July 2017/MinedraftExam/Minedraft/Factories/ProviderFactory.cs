using System;
using System.Collections.Generic;

public class ProviderFactory
{
    public Provider CreateProvider(List<string> args)
    {
        var type = args[0];
        var id = args[1];
        var energyOutput = double.Parse(args[2]);

        if(type == "Pressure")
        {
            return new PressureProvider(id, energyOutput);
        }
        else if(type == "Solar")
        {
            return new SolarProvider(id, energyOutput);
        }

        throw new ArgumentException(OutputMessages.InvalidProvider, type);
    }
}
