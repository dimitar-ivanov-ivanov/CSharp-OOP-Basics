public class HeavyHardware : Hardware
{

    public HeavyHardware(string name, int maximumCapacity, int minimumCapacity)
        : base(name, maximumCapacity, minimumCapacity)
    {
        this.MaximumMemory -= this.MaximumMemory * 25 / 100;
        this.MaximumCapacity *= 2;
    }
}
