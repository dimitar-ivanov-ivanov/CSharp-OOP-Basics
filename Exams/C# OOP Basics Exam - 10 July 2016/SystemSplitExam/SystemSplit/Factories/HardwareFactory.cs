using System;
using System.Linq;
using System.Reflection;

public class HardwareFactory
{
    private const string Suffix = "Hardware";

    public Hardware CreateHardware(string type, string name, int capacity, int memory)
    {
        var typeToActivate = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == type + Suffix);

        return (Hardware)Activator.CreateInstance(typeToActivate, name, capacity, memory);
    }
}
