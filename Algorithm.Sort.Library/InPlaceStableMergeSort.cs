namespace Algorithm.Sort.Library
{
    using System;

    public class InPlaceStableMergeSort
    {
        public static void Sort<T>(T[] array, SortType sortType) where T : IComparable
        {
            Sort(array, sortType, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, SortType sortType, int from, int to) where T : IComparable
        {
            if (from < to)
            {
                int middle = (from + to) / 2;
                Sort(array, sortType, from, middle);
                Sort(array, sortType, middle + 1, to);
                Merge(array, sortType, from, middle, to, middle - from + 1, to - middle);
            }
        }

        /// <summary>
        /// Sophisticated merge method
        /// </summary>
        private static void Merge<T>(T[] array, SortType sortType, int from, int middle, int to, int topHalfLength, int bottomeHalfLength) where T : IComparable
        {
            if (from <= middle && middle <= to)
            {
                int n = topHalfLength + bottomeHalfLength;
                if (n == 2)
                {
                    if (!Common.IsInOrder(array[from], array[to], sortType))
                    {
                        Common.Swap(ref array[from], ref array[to]);
                    }
                }
                else if (n > 2)
                {
                    int binaryInTopHalf = from + topHalfLength / 2;
                    int binaryInBottomHalf = RotateIndex(array, sortType, middle, to, array[binaryInTopHalf]);
                    if (binaryInBottomHalf > middle)
                    {
                        Common.GriesMillsBlockSwap(array, binaryInTopHalf, middle, binaryInBottomHalf);
                        int movedToTopHalfLength = binaryInBottomHalf - middle;
                        int movedToBottomHalfLength = middle - binaryInTopHalf + 1;
                        Merge(array, sortType, from, binaryInTopHalf - 1, binaryInTopHalf + movedToTopHalfLength - 1, topHalfLength - movedToBottomHalfLength, movedToTopHalfLength);
                        Merge(array, sortType, binaryInBottomHalf - movedToBottomHalfLength + 1, binaryInBottomHalf, to, movedToBottomHalfLength, bottomeHalfLength - movedToTopHalfLength);
                    }
                }
            }
        }

        /// <summary>
        /// Binary search index of the last greater/smaller element than value from sorted array [from...to]
        /// </summary>
        private static int RotateIndex<T>(T[] array, SortType sortType, int from, int to, T value) where T : IComparable
        {
            if (!Common.IsInOrder(value, array[to], sortType))
            {
                return to;
            }
            if (from < to)
            {
                int length = to - from + 1;
                while (length > 0)
                {
                    int middle = from + length / 2;
                    if (!Common.IsInOrder(value, array[middle], sortType))
                    {
                        from = middle;
                    }
                    length = length / 2;
                }
            }
            return from;
        }

        /// <summary>
        /// Naive merge method
        /// </summary>
        private static void Merge<T>(T[] array, SortType sortType, int from, int middle, int to) where T : IComparable
        {
            int i = from, j = middle + 1;

            while (i <= middle && j <= to)
            {
                if (!Common.IsInOrder(array[i], array[j], sortType))
                {
                    T temp = array[j];
                    for (int k = j; k > i; k--)
                    {
                        array[k] = array[k - 1];
                    }
                    array[i] = temp;
                    ++middle;
                    ++j;
                }
                ++i;
            }
        }
    }
}