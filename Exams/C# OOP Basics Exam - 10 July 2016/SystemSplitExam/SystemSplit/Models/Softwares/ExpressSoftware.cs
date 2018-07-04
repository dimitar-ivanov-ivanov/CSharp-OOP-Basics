public class ExpressSoftware : Software
{
    private const int MemoryMultiplier = 2;

    public ExpressSoftware(string name, int capacityConsumption, int memoryConsumption) 
        : base(name, capacityConsumption, memoryConsumption)
    {
        this.MemoryConsumption *= MemoryMultiplier;
    }
}
