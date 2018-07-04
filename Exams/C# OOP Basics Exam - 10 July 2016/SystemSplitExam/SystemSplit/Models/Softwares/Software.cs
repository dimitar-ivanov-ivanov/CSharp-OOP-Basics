public abstract class Software
{
    protected Software(string name, int capacityConsumption, int memoryConsumption)
    {
        Name = name;
        CapacityConsumption = capacityConsumption;
        MemoryConsumption = memoryConsumption;
    }

    public string Name { get; }

    public string Type
    {
        get
        {
            var typeFullName = this.GetType().Name;
            var typeName = typeFullName.Substring(0, typeFullName.Length - "Software".Length);

            return typeName;
        }
    }

    public int CapacityConsumption { get; protected set; }

    public int MemoryConsumption { get; protected set; }
}
