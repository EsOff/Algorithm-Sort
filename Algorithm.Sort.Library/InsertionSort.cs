namespace Algorithm.Sort.Library
{
    using System;

    public class InsertionSort
    {
        public static void Sort<T>(T[] array, SortType sortType) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (!Common.IsInOrder(array[i - 1], array[i], sortType))
                {
                    T key = array[i];
                    int j = i;
                    // to find key's correct position in array.
                    while (j > 0 && !Common.IsInOrder(array[j - 1], key, sortType))
                    {
                        array[j] = array[j - 1]; // move current value backward in turn.
                        j--;
                    }
                    array[j] = key;
                }
            }
        }
    }
}
