namespace Car_Salesman.Models
{
    using System;

    public class CarEngine
    {
        private string model;
        private double power;
        private double displacement;
        private string efficiency;

        public string Model { get => model; private set => model = value; }

        public double Power { get => power; private set => power = value; }

        public double Displacement { get => displacement; private set => displacement = value; }

        public string Efficiency { get => efficiency; private set => efficiency = value; }

        public CarEngine(string model, double power)
        {
            this.model = model;
            this.power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }

        public static CarEngine Parse(string input)
        {
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var model = args[0];
            var power = double.Parse(args[1]);

            var engine = new CarEngine(model, power);

            if (args.Length > 2)
            {
                double val = 0;
                if (double.TryParse(args[2], out val))
                {
                    engine.Displacement = val;
                }
                else
                {
                    engine.Efficiency = args[2];
                }
            }
            if (args.Length > 3)
            {
                engine.Efficiency = args[3];
            }

            return engine;
        }

        public override string ToString()
        {
            var displacementOutput = this.Displacement == -1 ? "n/a" : this.Displacement.ToString();

            return $"  {this.Model}:\n" +
                   $"    Power: {this.Power}\n" +
                   $"    Displacement: {displacementOutput}\n" +
                   $"    Efficiency: {this.Efficiency}";
        }
    }
}
