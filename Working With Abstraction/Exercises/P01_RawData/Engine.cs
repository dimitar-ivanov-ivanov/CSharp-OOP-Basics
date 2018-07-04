namespace P01_RawData
{
    public class Engine
    {
        private int engineSpeed;
        private int enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }

        public int EngineSpeed { get => engineSpeed; set => engineSpeed = value; }

        public int EnginePower { get => enginePower; set => enginePower = value; }
    }
}
