public class EarthBender : Bender
{
    public EarthBender(string name, int power,double groundSaturation)
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation { get; }

    public override double GetTotalPower()
    {
        return this.Power * this.GroundSaturation;
    }

    public override string ToString()
    {
        return $"Earth Bender: {this.Name}, Power: {this.Power}, Ground Saturation: {this.GroundSaturation:f2}";
    }
}
