using System;
using System.Linq;
using System.Reflection;

public class RaceFactory : IRaceFactory
{
    private const string Suffix = "Race";

    public IRace CreateRace(string type, int length, string route, int prizePool)
    {
        var typeToActivate = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(x => x.Name == type + Suffix);

        var race = (IRace)Activator.CreateInstance(typeToActivate, length, route, prizePool);

        return race;
    }
}
