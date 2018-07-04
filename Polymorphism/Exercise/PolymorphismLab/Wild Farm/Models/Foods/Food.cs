namespace Wild_Farm.Models.Foods
{
    public abstract class Food
    {
        private int quantity;

        public Food(int quantity)
        {
            this.quantity = quantity;
        }

        public int Quantity
        {
            get { return this.quantity; }
            private set { this.quantity = value; }
        }

    }
}
