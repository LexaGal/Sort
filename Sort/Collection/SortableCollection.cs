using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sort.Collection
{
    public class SortableCollection<T> : ISortableCollection<T> where T : IComparable<T>
    {
        public T[] Items { get; private set; }
        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }

        public SortableCollection(T[] items)
        {
            Items = items;
            Count = Items.Length;
            IsReadOnly = false;
        }

        public SortableCollection()
        {
            Items = new T[]{};
            IsReadOnly = false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>) Items.GetEnumerator();
        }

        public void Add(T item)
        {
            T[] arr = new T[Items.Length + 1];
            Items.CopyTo(arr, 0);
            arr[arr.Length - 1] = item;
            Items = arr;
            Count++;
        }

        public void Clear()
        {
            Array.Clear(Items.ToArray(), 0, Items.Length);
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Items.CopyTo(array, 0);
        }

        public bool Remove(T item)
        {
            if (Items.Length > 0)
            {
                Items = Array.FindAll(Items, obj => !obj.Equals(item));
                Count = Items.Length;
                return true;
            }
            return false;
        }

        public ISortableCollection<T> Clone()
        {
            return new SortableCollection<T>(Items.Clone() as T[]);
        }

        public void AddRange(T[] items)
        {
            foreach (var it in items)
            {
                Add(it);
            }
        }

        public void RemoveAt(int pos)
        {
            T[] arr1 = new T[Items.Length - 1];
            T[] arr2 = new T[Items.Length - pos -  1];

            Array.ConstrainedCopy(Items, 0, arr1, 0, pos);
            Array.ConstrainedCopy(Items, pos + 1, arr2, 0, Items.Length - pos - 1);
            Array.ConstrainedCopy(arr2, 0, arr1, pos, arr2.Length);

            Items = arr1;
            Count--;
        }

        public T this[int i]
        {
            get { return Items[i]; }
            set { Items[i] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            //foreach (T it in Items)
            //{
            //    builder.AppendFormat("{0}, ", it);
            //}
            return builder.ToString();
        }
    }
}