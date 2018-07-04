namespace Collection_Hierarchy.Models
{
    using System.Collections.Generic;
    using Collection_Hierarchy.Contracts;

    public class AddCollection<T> : IAddCollection<T>
    {
        private IList<T> data;

        public AddCollection()
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
            data.Add(element);
            return this.data.Count - 1;
        }
    }
}
