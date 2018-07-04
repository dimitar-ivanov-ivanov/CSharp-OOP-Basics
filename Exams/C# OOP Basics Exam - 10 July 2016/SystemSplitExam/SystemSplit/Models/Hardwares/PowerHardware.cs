public class PowerHardware : Hardware
{
    public PowerHardware(string name, int maximumCapacity, int maximumMemory) 
        : base(name, maximumCapacity, maximumMemory)
    {
        this.MaximumCapacity -= this.MaximumCapacity * 75 / 100;
        this.MaximumMemory += this.MaximumMemory * 75 / 100;
    }
}