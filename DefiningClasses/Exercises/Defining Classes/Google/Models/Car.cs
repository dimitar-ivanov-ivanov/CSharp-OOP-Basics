namespace Google.Models
{
    public class Car
    {
        private string carModel;
        private int carSpeed;

        public Car(string carModel, int carSpeed)
        {
            this.carModel = carModel;
            this.carSpeed = carSpeed;
        }

        public string CarModel { get => carModel; private set => carModel = value; }
        public int CarSpeed { get => carSpeed; private set => carSpeed = value; }

        public override string ToString()
        {
            return $"{this.CarModel} {this.CarSpeed}";
        }
    }
}
