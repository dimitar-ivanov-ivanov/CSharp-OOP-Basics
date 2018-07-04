using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CommandCenter
{
    private IDictionary<string, Hardware> hardwares;
    private SoftwareFactory softwareFactory;
    private HardwareFactory hardwareFactory;
    private IDictionary<string, Hardware> dump;

    public CommandCenter()
    {
        this.hardwares = new Dictionary<string, Hardware>();
        this.dump = new Dictionary<string, Hardware>();
        this.softwareFactory = new SoftwareFactory();
        this.hardwareFactory = new HardwareFactory();
    }

    public void RegisterPowerHardware(string name, int capacity, int memory)
    {
        RegisterHardware("Power", name, capacity, memory);
    }

    public void RegisterHeavyHardware(string name, int capacity, int memory)
    {
        RegisterHardware("Heavy", name, capacity, memory);
    }

    private void RegisterHardware(string type, string name, int capacity, int memory)
    {
        var hardware = hardwareFactory.CreateHardware(type, name, capacity, memory);
        hardware.ToString();

        if (!hardwares.ContainsKey(name))
        {
            hardwares.Add(name, hardware);
        }
    }

    public void RegisterExpressSoftware(string hardwareComponentName, string name, int capacity, int memory)
    {
        RegisterSoftware("Express", hardwareComponentName, name, capacity, memory);
    }

    public void RegisterLightSoftware(string hardwareComponentName, string name, int capacity, int memory)
    {
        RegisterSoftware("Light", hardwareComponentName, name, capacity, memory);
    }

    private void RegisterSoftware(string type, string hardwareComponent, string name, int capacity, int memory)
    {
        var software = softwareFactory.CreateSoftware(type, name, capacity, memory);

        if (hardwares.ContainsKey(hardwareComponent))
        {
            hardwares[hardwareComponent].AddSoftware(software);
        }
    }

    public void ReleaseSoftwareComponent(string hardwareComponentName, string softwareComponentName)
    {
        if (hardwares.ContainsKey(hardwareComponentName))
        {
            hardwares[hardwareComponentName].Remove(softwareComponentName);
        }
    }

    public string Analyze()
    {
        var hardwareComponentsCount = this.hardwares.Count;
        var softwareComponentsCount = this.hardwares.Sum(x => x.Value.SoftwareComponents);

        var memoryUsed = this.hardwares.Sum(x => x.Value.MemoryTaken);
        var maximumMemory = this.hardwares.Sum(x => x.Value.MaximumMemory);

        var capacityUsed = this.hardwares.Sum(x => x.Value.CapacityTaken);
        var maximumCapacity = this.hardwares.Sum(x => x.Value.MaximumCapacity);

        return "System Analysis\n" +
               $"Hardware Components: {hardwareComponentsCount}\n" +
               $"Software Components: {softwareComponentsCount}\n" +
               $"Total Operational Memory: {memoryUsed} / {maximumMemory}\n" +
               $"Total Capacity Taken: {capacityUsed} / {maximumCapacity}";
    }

    public string SystemSplit()
    {
        var powerHardware = this.hardwares.Values.Where(x => x.Type == "Power");
        var heavyHardware = this.hardwares.Values.Where(x => x.Type == "Heavy");

        var orderedHardwares = powerHardware.Concat(heavyHardware);

        var builder = new StringBuilder();

        foreach (var hardware in orderedHardwares)
        {
            builder.AppendLine(hardware.ToString());
        }

        return builder.ToString().TrimEnd();
    }

    public void Dump(string hardwareComponentName)
    {
        if (this.hardwares.ContainsKey(hardwareComponentName))
        {
            var hardwareToRemove = this.hardwares[hardwareComponentName];
            this.dump.Add(hardwareToRemove.Name, hardwareToRemove);
            this.hardwares.Remove(hardwareComponentName);
        }
    }

    public void Restore(string hardwareComponentName)
    {
        if (this.dump.ContainsKey(hardwareComponentName))
        {
            var toRemove = this.dump[hardwareComponentName];
            this.hardwares.Add(hardwareComponentName, toRemove);
            this.dump.Remove(hardwareComponentName);
        }
    }

    public void Destroy(string hardwareComponentName)
    { 
       if (this.dump.ContainsKey(hardwareComponentName))
        {
            this.dump.Remove(hardwareComponentName);
        }
    }

    public string DumpAnalyze()
    {
        var powerHardware = this.dump.Values.Where(x => x.Type == "Power").Count();
        var heavyHardware = this.dump.Values.Where(x => x.Type == "Heavy").Count();

        var expressCount = this.dump.Values
            .Sum(x => x.ExpressCount);

        var lightCount = this.dump.Values
            .Sum(x => x.LightCount);

        var totalDumpedMemory = this.dump.Values.Sum(x => x.MaximumMemory);
        var totalDumpedCapacity = this.dump.Values.Sum(x => x.MaximumCapacity);

        return "Dump Analysis\n" + 
               $"Power Hardware Components: {powerHardware}\n" +
               $"Heavy Hardware Components: {heavyHardware}\n" + 
               $"Express Software Components: {expressCount}\n" + 
               $"Light Software Components: {lightCount}\n" + 
               $"Total Dumped Memory: {totalDumpedCapacity}\n" + 
               $"Total Dumped Capacity: {totalDumpedCapacity}";
    }
}

