namespace Create_Ferrari.Models
{
    using Create_Ferrari.Contracts;

    public class Ferrari : ICar
    {
        private string model;
        private string driver;

        public Ferrari(string driver, string model = "488-Spider")
        {
            this.model = model;
            this.driver = driver;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public string Driver
        {
            get { return this.driver; }
            private set { this.driver = value; }
        }

        public string PushGas()
        {
            return "Zadu6avam sA!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.UseBrakes()}/{this.PushGas()}/{this.Driver}";
        }
    }
}
