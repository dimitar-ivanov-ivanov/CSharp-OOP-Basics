using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Hardware
{
    private IDictionary<string, Software> softwares;

    protected Hardware(string name, int maximumCapacity, int minimumCapacity)
    {
        Name = name;
        MaximumCapacity = maximumCapacity;
        MaximumMemory = minimumCapacity;
        this.softwares = new Dictionary<string, Software>();
    }

    public int SoftwareComponents => this.softwares.Count;

    public int ExpressCount => this.softwares.Where(x => x.Value.Type == "Express").Count();

    public int LightCount => this.softwares.Where(x => x.Value.Type == "Light").Count();

    public string Name { get; }

    public string Type
    {
        get
        {
            var typeFullName = this.GetType().Name;
            var typeName = typeFullName.Substring(0, typeFullName.Length - "Hardware".Length);

            return typeName;
        }
    }

    public int MaximumCapacity { get; protected set; }

    public int MaximumMemory { get; protected set; }

    public int MemoryTaken => this.softwares.Sum(x => x.Value.MemoryConsumption);

    public int CapacityTaken => this.softwares.Sum(x => x.Value.CapacityConsumption);

    public void AddSoftware(Software software)
    {
        if (!this.softwares.ContainsKey(software.Name) &&
            this.MemoryTaken + software.MemoryConsumption <= this.MaximumMemory &&
            this.CapacityTaken + software.CapacityConsumption <= this.MaximumCapacity)
        {
            this.softwares.Add(software.Name, software);
        }
    }

    public void Remove(string softwareComponentName)
    {
        if (this.softwares.ContainsKey(softwareComponentName))
        {
            this.softwares.Remove(softwareComponentName);
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine($"Hardware Component – {this.Name}");
        builder.AppendLine($"Express Software Components - {ExpressCount}");
        builder.AppendLine($"Light Software Components - {LightCount}");
        builder.AppendLine($"Memory Usage: {this.MemoryTaken} / {this.MaximumMemory}");
        builder.AppendLine($"Capacity Usage: {this.CapacityTaken} / {this.MaximumCapacity}");
        builder.AppendLine($"Type: {this.Type}");

        if (this.softwares.Count == 0)
        {
            builder.AppendLine($"Software Components: None");
        }
        else
        {
            var softwareComponentNames = this.softwares.Select(x => x.Key).ToArray();
            var softwareComponentNamesStr = string.Join(", ", softwareComponentNames);

            builder.AppendLine($"Software Components: {softwareComponentNamesStr}");
        }

        return builder.ToString().TrimEnd();
    }
}