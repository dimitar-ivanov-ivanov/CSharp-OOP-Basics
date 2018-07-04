namespace Raw_Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Car
    {
        private string model;
        private CarEngine engine;
        private Cargo cargo;
        private List<Tyre> tyres;

        public Car(string model, CarEngine engine, Cargo cargo, List<Tyre> tyres)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tyres = tyres;
        }

        public string Model { get => model; private set => model = value; }

        public CarEngine Engine { get => engine; private set => engine = value; }

        public Cargo Cargo { get => cargo; private set => cargo = value; }

        public List<Tyre> Tyres { get => tyres; private set => tyres = value; }

        public static Car Parse(string input)
        {
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = args[0];

            var engineSpeed = int.Parse(args[1]);
            var enginePower = int.Parse(args[2]);
            var engine = new CarEngine(engineSpeed, enginePower);

            var cargoWeight = int.Parse(args[3]);
            var cargoType = args[4];
            var cargo = new Cargo(cargoWeight, cargoType);

            var tyre1Pressure = double.Parse(args[5]);
            var tyre1Age = int.Parse(args[6]);

            var tyre2Pressure = double.Parse(args[7]);
            var tyre2Age = int.Parse(args[8]);

            var tyre3Pressure = double.Parse(args[9]);
            var tyre3Age = int.Parse(args[10]);

            var tyre4Pressure = double.Parse(args[11]);
            var tyre4Age = int.Parse(args[12]);

            var tyre1 = new Tyre(tyre1Pressure, tyre1Age);
            var tyre2 = new Tyre(tyre2Pressure, tyre2Age);
            var tyre3 = new Tyre(tyre3Pressure, tyre3Age);
            var tyre4 = new Tyre(tyre4Pressure, tyre4Age);

            var tyres = new List<Tyre>() { tyre1, tyre2, tyre3, tyre4 };

            return new Car(model, engine, cargo, tyres);
        }

        public override string ToString()
        {
            return this.Model;
        }
    }
}
