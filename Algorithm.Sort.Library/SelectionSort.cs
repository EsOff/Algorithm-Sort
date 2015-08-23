namespace Algorithm.Sort.Library
{
    using System;

    public class SelectionSort
    {
        public static void Sort<T>(T[] array, SortType sortType) where T : IComparable
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                // assume the min is the first element
                int minIndex = j;
                // find the real min element in the unsorted array[j+1...n-1]
                for (int i = j + 1; i < array.Length; i++)
                {
                    if (!Common.IsInOrder(array[minIndex], array[i], sortType))
                    {
                        minIndex = i;
                    }
                }
                // swap real min element to start location
                if (minIndex != j)
                {
                    Common.Swap(ref array[j], ref array[minIndex]);
                }
            }
        }
    }
}