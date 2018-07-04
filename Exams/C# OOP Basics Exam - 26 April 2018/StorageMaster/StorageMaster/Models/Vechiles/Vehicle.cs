using StorageMaster.Constants;
using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Vechiles
{
    public abstract class Vehicle
    {
        private readonly List<Product> trunk;

        protected Vehicle(int capacity)
        {
            Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity { get; }

        public IReadOnlyCollection<Product> Trunk => trunk;

        public bool IsFull => this.trunk.Sum(x => x.Weight) >= this.Capacity;

        public bool IsEmpty => this.trunk.Count == 0;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(OutputMessages.VechileFull);
            }
            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException(OutputMessages.VechileEmpty);
            }

            var toRemove = this.trunk.Last();
            this.trunk.RemoveAt(this.trunk.Count - 1);
            return toRemove;
        }

    }
}
