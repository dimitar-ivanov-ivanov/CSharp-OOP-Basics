namespace P01_RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private CargoWeight cargo;
        private Tyre[] tires;

        public Car(string model, int engineSpeed, int enginePower, 
            int cargoWeight, string cargoType, double tire1Pressure, 
            int tire1Age, double tire2Pressure, int tire2Age, 
            double tire3Pressure, int tire3age, double tire4Pressure, 
            int tire4age)
        {
            this.model = model;
            this.engine = new Engine(engineSpeed, enginePower);
            this.cargo = new CargoWeight(cargoWeight, cargoType);

            this.tires = new Tyre[]
            {
              new Tyre(tire1Pressure, tire1Age),
              new Tyre(tire2Pressure, tire2Age),
              new Tyre(tire3Pressure, tire3age),
              new Tyre(tire4Pressure, tire4age)
            };
        }

        public string Model { get => model; set => model = value; }

        public Engine Engine { get => engine; set => engine = value; }

        public CargoWeight Cargo { get => cargo; set => cargo = value; }

        public Tyre[] Tires { get => tires; set => tires = value; }
    }
}
