using System;
using Sort.Collection;

namespace Sort.Algorithms
{
    public class SelectionSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        public override ISortableCollection<T> Sort(ISortableCollection<T> collection)
        {
            Collection = collection;
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    CompareCounter++; 
                    
                    if (collection[j].CompareTo(collection[min]) == -1)
                    {
                       min = j;
                    }
                }
                T dummy = collection[i];
                collection[i] = collection[min];
                collection[min] = dummy;

                SwapCounter++;
            }
            return collection;
        }

        public override string ToString()
        {
            return string.Format("{0} - Selection sort", base.ToString());
        }
    }
}