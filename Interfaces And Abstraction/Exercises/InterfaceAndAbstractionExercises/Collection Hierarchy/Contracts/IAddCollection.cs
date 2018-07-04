using System.Collections.Generic;

namespace Collection_Hierarchy.Contracts
{
    public interface IAddCollection<T>
    {
        IList<T> Data { get; }

        int Add(T element);
    }
}
