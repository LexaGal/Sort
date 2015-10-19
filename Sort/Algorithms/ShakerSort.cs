using System;
using Sort.Collection;

namespace Sort.Algorithms
{
    public class ShakeSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        public override ISortableCollection<T> Sort(ISortableCollection<T> collection)
        {
            Collection = collection;
            for (int i = 0; i < collection.Count/2; i++)
            {
                int beg = 0;
                int end = collection.Count - 1;

                do
                {
                    CompareCounter += 2;

                    if (collection[beg].CompareTo(collection[beg + 1]) == 1)
                    {
                        Swap(collection, beg, beg + 1);
                    }
                    beg++;

                    if (collection[end - 1].CompareTo(collection[end]) == 1)
                    {
                        Swap(collection, end - 1, end);
                    }
                    end--;

                } while (beg <= end);
            }
            return collection;
        }

        private void Swap(ISortableCollection<T> collection, int i, int j)
        {
            T item = collection[i];
            collection[i] = collection[j];
            collection[j] = item;

            SwapCounter++;
        }

        public override string ToString()
        {
            return string.Format("{0} - Shake sort", base.ToString());
        }
    }
}