namespace Cars.Models
{
    using Cars.Contracts;

    public abstract class Car : ICar
    {
        private string model;
        private string color;

        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public string Color
        {
            get { return this.color; }
            private set { this.color = value; }
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }
    }
}
