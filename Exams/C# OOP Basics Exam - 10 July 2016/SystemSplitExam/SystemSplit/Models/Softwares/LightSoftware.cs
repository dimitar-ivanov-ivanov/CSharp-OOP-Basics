public class LightSoftware : Software
{
    public LightSoftware(string name, int capacityConsumption, int memoryConsumption) 
        : base(name, capacityConsumption, memoryConsumption)
    {
        this.CapacityConsumption += this.CapacityConsumption * 50 / 100;
        this.MemoryConsumption -= this.MemoryConsumption * 50 / 100;
    }
}