using System;
using Sort.Collection;

namespace Sort.Algoritms
{
    public abstract class SortAlgorithm<T> where T : IComparable<T>
    {
        public int SwapCounter { get; set; }
        public int CompareCounter { get; set; }
        protected ISortableCollection<T> Collection; 
        
        public abstract ISortableCollection<T> Sort(ISortableCollection<T> collection);

        public override string ToString()
        {
            return string.Format("{0}Compares: {1}, Swaps: {2}", Collection, CompareCounter, SwapCounter);
        }
    }
}