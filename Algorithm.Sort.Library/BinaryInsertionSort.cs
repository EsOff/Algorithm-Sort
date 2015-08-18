namespace Algorithm.Sort.Library
{
    using System;

    public class BinaryInsertionSort
    {
        public static void Sort<T>(T[] array, SortType sortType) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (!Common.IsInOrder(array[i - 1], array[i], sortType))
                {
                    T key = array[i];

                    // binary search key's right position.
                    int left = 0; // search lower bound
                    int rigth = i - 1; // search upper bound
                    while (left <= rigth)
                    {
                        int middle = (left + rigth) / 2;
                        if (Common.IsInOrder(array[middle], key, sortType))
                        {
                            left = middle + 1; // move forward
                        }
                        else
                        {
                            rigth = middle - 1; // move backward
                        }
                    }

                    // move current value backward in turn.
                    for (int j = i; j > left; j--)
                    {
                        array[j] = array[j - 1];
                    }

                    // insert key.
                    array[left] = key;
                }
            }
        }
    }
}
