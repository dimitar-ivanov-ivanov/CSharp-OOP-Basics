namespace Raw_Data.Models
{
    public class CarEngine
    {
        private int speed;
        private int power;

        public CarEngine(int speed, int power)
        {
            this.speed = speed;
            this.power = power;
        }

        public int Power { get => power; private set => power = value; }
        public int Speed { get => speed; private set => speed = value; } 
    }
}
