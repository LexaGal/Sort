using System;
using Sort.Algoritms;
using Sort.Collection;

namespace Sort
{
    class Program
    {
        private static void Main()
        {
            ISortableCollection<Item> sortableCollection = new SortableCollection<Item>(new[]
            {
                new Item(12),
                new Item(34),
                new Item(12),
                new Item(3.5),
                new Item(4.7),
                new Item(0.67)
            });
            sortableCollection.AddRange(new[]
            {
                new Item(45),
                new Item(5.6),
                new Item(12.5),
                new Item(1.2),
                new Item(340),
                new Item(155),
                new Item(30.5),
                new Item(4.76),
                new Item(0.174)
            });

            ISortableCollection<Item> collection1 = sortableCollection.Clone();
            ISortableCollection<Item> collection2 = sortableCollection.Clone();
            ISortableCollection<Item> collection3 = sortableCollection.Clone();

            collection1.Remove(collection1[0]);

            collection2.RemoveAt(collection2.Count - 1);

            SortAlgorithm<Item> selectionSort = new SelectionSort<Item>();
            SortAlgorithm<Item> shakeSort = new ShakeSort<Item>();
            SortAlgorithm<Item> heapSort = new HeapSort<Item>();

            selectionSort.Sort(collection1);
            shakeSort.Sort(collection2);
            heapSort.Sort(collection3);

            Console.WriteLine(selectionSort);
            Console.WriteLine(shakeSort);
            Console.WriteLine(heapSort);
            Console.ReadKey();
        }
    }
}
