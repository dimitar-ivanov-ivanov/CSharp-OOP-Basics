namespace DungeonsAndCodeWizards.Models.Bags
{
    using DungeonsAndCodeWizards.Constants;
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Bag
    {
        private const int DefaultCapacity = 100;
        private readonly List<Item> items;

        protected Bag(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        int Capacity { get; }

        public int Load => this.items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight >= this.Capacity)
            {
                throw new InvalidOperationException(OutputMessages.BagFull);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(OutputMessages.BagEmpty);
            }

            var foundItem = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (foundItem == null)
            {
                throw new ArgumentException(OutputMessages.NameDoesntExistInBag, name);
            }

            this.items.Remove(foundItem);
            return foundItem;
        }
    }
}
