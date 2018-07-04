namespace P01_RawData
{
    public class CargoWeight
    {
        private int weight;
        private string type;

        public CargoWeight(int weight, string type)
        {
            this.weight = weight;
            this.type = type;
        }

        public int Weight { get => weight; set => weight = value; }

        public string Type { get => type; set => type = value; }
    }
}
