using System;
using System.Linq;
using System.Reflection;

public class SoftwareFactory
{
    private const string Suffix = "Software";

    public Software CreateSoftware(string type, string name, int capacity, int memory)
    {
        var typeToActivate = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == type  + Suffix);

        return (Software)Activator.CreateInstance(typeToActivate, name, capacity, memory);
    }
}
