using System;
using System.Collections.Generic;

namespace Sort.Collection
{
    public interface ISortableCollection<T>: ICollection<T> where T : IComparable<T>
    {
        T[] Items { get; }
        T this[int i] { get; set; }
        ISortableCollection<T> Clone();
        void AddRange(T[] items);
        void RemoveAt(int pos);
    }
}