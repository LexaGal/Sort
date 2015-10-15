using System;
using Sort.Collection;

namespace Sort.Algoritms
{
    public class HeapSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        public override ISortableCollection<T> Sort(ISortableCollection<T> collection)
        {
            Collection = collection;
            for (int i = collection.Count / 2 - 1; i >= 0; i--)
            {
                ShiftDown(collection, i, collection.Count);
            }
            for (int i = collection.Count - 1; i >= 1; i--)
            {
                T temp = collection[0];
                collection[0] = collection[i];
                collection[i] = temp;
                
                SwapCounter++;
                
                ShiftDown(collection, 0, i);
            }
            return collection;
        }

        private void ShiftDown(ISortableCollection<T> collection, int i, int j)
        {
            bool done = false;

            while ((i*2 + 1 < j) && (!done))
            {
                int maxChild;
                
                if (i*2 + 1 == j - 1)
                {
                    maxChild = i*2 + 1;
                
                    CompareCounter++;
                }
                else if (collection[i*2 + 1].CompareTo(collection[i*2 + 2]) == 1)
                {
                    maxChild = i*2 + 1;

                    CompareCounter += 2;
                }
                else
                {
                    maxChild = i*2 + 2;
                    CompareCounter += 3;
                }

                CompareCounter++;

                if (collection[i].CompareTo(collection[maxChild]) == -1)
                {
                    T temp = collection[i];
                    collection[i] = collection[maxChild];
                    collection[maxChild] = temp;
                    i = maxChild;

                    SwapCounter++;
                }
                else
                {
                    done = true;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - Heap sort", base.ToString());
        }
    }
}