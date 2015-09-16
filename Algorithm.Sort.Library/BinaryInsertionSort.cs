namespace Algorithm.Sort.Library
{
    using System;

    public class BinaryInsertionSort
    {
        public static void Sort<T>(T[] array, SortType sortType) where T : IComparable
        {
            Sort(array, sortType, 0, array.Length - 1);
        }

        public static void Sort<T>(T[] array, SortType sortType, int from, int to) where T : IComparable
        {
            for (int i = from + 1; i <= to; i++)
            {
                if (!Common.IsInOrder(array[i - 1], array[i], sortType))
                {
                    T key = array[i];

                    // binary search key's right position.
                    int index = BinarySearch(array, sortType, key, from, i - 1);

                    // move current value backward in turn.
                    for (int j = i; j > index; j--)
                    {
                        array[j] = array[j - 1];
                    }

                    // insert key.
                    array[index] = key;
                }
            }
        }

        private static int BinarySearch<T>(T[] array, SortType sortType, T key, int from, int to) where T : IComparable
        {
            while (from <= to)
            {
                int middle = (from + to) / 2;
                if (Common.IsInOrder(array[middle], key, sortType))
                {
                    from = middle + 1; // move forward
                }
                else
                {
                    to = middle - 1; // move backward
                }
            }
            return from;
        }
    }
}
