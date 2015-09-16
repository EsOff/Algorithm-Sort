namespace Algorithm.Sort.Library
{
    using System;

    public class QuickSort
    {
        private static Random random = new Random();

        public static void Sort<T>(T[] array, SortType sortType) where T : IComparable
        {
            Sort(array, 0, array.Length - 1, sortType);
        }

        private static void Sort<T>(T[] array, int left, int right, SortType sortType) where T : IComparable
        {
            if (left < right)
            {
                int index = Partition(array, left, right, sortType);
                Sort(array, left, index - 1, sortType);
                Sort(array, index + 1, right, sortType);
            }
        }

        /// <summary>
        /// Places the pivot element at its correct location in sorted array,
        /// and places all smaller elements to left of pivot and all greater elements to right of pivot in ascending order.
        ///</summary>
        private static int Partition<T>(T[] array, int left, int right, SortType sortType) where T : IComparable
        {
            T pivot = array[random.Next(left, right)]; // random select an element in array as pivot.

            while (true)
            {
                while (!Common.IsInOrder(pivot, array[left], sortType))
                {
                    left++; // find 1st greater or equal element in left in ascending order.
                }

                while (!Common.IsInOrder(array[right], pivot, sortType))
                {
                    right--; // find 1st smaller or equal element in right in asceding order.
                }

                if (left < right) // swap left and right elements to make sure left <= pivot <= right in asceding order.
                {
                    Common.Swap(ref array[left], ref array[right]);
                }
                else // left >= right
                {
                    return right; // pivot's correct location
                }
            }
        }
    }
}
