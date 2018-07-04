namespace Car_Salesman.Models
{
    public class Car
    {
        private string model;
        private CarEngine carEngine;
        private double weight;
        private string color;

        public Car(string model, CarEngine carEngine)
        {
            this.model = model;
            this.carEngine = carEngine;
            this.Weight = -1;
            this.Color = "n/a";
        }

        public string Model { get => model; private set => model = value; }

        public CarEngine CarEngine { get => carEngine; private set => carEngine = value; }

        public double Weight { get => weight; private set => weight = value; }

        public string Color { get => color; private set => color = value; }

        public static Car Parse(string model, CarEngine carEngine, params string[] additionalArgs)
        {
            var car = new Car(model, carEngine);

            if (additionalArgs.Length > 0)
            {
                double val = 0;
                if (double.TryParse(additionalArgs[0], out val))
                {
                    car.Weight = val;
                }
                else
                {
                    car.Color = additionalArgs[0];
                }
            }

            if (additionalArgs.Length > 1)
            {
                car.Color = additionalArgs[1];
            }

            return car;
        }

        public override string ToString()
        {
            var weightOutput = this.Weight == -1 ? "n/a"
                : this.Weight.ToString();

            return $"{this.Model}:\n" +
                   $"{this.CarEngine}\n" +
                   $"  Weight: {weightOutput}\n" +
                   $"  Color: {this.Color}";
        }
    }
}
