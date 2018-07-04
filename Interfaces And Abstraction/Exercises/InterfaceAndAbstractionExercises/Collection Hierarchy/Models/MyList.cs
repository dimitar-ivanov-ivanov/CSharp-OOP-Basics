namespace Collection_Hierarchy.Models
{
    using System.Collections.Generic;
    using Collection_Hierarchy.Contracts;

    public class MyList<T> : IMyList<T>
    {
        private IList<T> data;

        public MyList()
        {
            this.data = new List<T>();
        }

        public IList<T> Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public int Used => this.Data.Count;

        public int Add(T element)
        {
            this.data.Insert(0, element);
            return 0;
        }

        public T Remove()
        {
            var toRemove = this.data[0];
            this.data.RemoveAt(0);
            return toRemove;
        }
    }
}
