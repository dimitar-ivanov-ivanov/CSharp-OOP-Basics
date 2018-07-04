namespace Raw_Data.Models
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int weight, string type)
        {
            this.weight = weight;
            this.type = type;
        }

        public int Weight { get => weight; private set => weight = value; }

        public string Type { get => type; private set => type = value; }
    }
}
