namespace Algorithm.Sort.Library
{
    using System;

    public class BubbleSort
    {
        public static void Sort<T>(T[] array, SortType sortType) where T : IComparable
        {
            bool isInOrder = false;
            int index = array.Length;
            do
            {
                isInOrder = false;
                for (int i = 1; i < index; i++)
                {
                    if (!Common.IsInOrder(array[i - 1], array[i], sortType))
                    {
                        Common.Swap(ref array[i - 1], ref array[i]);
                        isInOrder = true;
                    }
                }
                index--;
            } while (isInOrder);
        }
    }
}
