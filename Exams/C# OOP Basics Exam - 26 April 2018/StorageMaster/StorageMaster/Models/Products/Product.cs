using StorageMaster.Constants;
using System;

namespace StorageMaster.Models.Products
{
    public abstract class Product
    {
        private const double MinBase = 0;

        private double price;

        protected Product(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }

        public double Price
        {
            get { return this.price; }
            private set
            {
                if(value < MinBase)
                {
                    throw new InvalidOperationException(OutputMessages.NegativePrice);
                }
                this.price = value;
            }
        }

        public double Weight { get; }
    }
}
