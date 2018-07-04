namespace Collection_Hierarchy.Models
{
    using System.Collections.Generic;
    using Collection_Hierarchy.Contracts;

    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private IList<T> data;

        public AddRemoveCollection()
        {
            this.data = new List<T>();
        }

        public IList<T> Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public int Add(T element)
        {
            this.data.Insert(0, element);
            return 0;
        }

        public T Remove()
        {
            var toRemove = this.data[data.Count - 1];
            this.data.RemoveAt(data.Count - 1);
            return toRemove;
        }
    }
}
