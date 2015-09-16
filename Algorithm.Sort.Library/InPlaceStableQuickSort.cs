namespace Algorithm.Sort.Library
{
    using System;

    public class InPlaceStableQuickSort
    {
        /// <summary>
        /// The minimum size of the temporary array. It is used to speed up sorting small blocks.
        /// </summary>
        private static readonly int TEMP_SIZE = 1024;

        /// <summary>
        /// Blocks smaller than 16 are sorted using binary insertion sort. This usually speeds up sorting.
        /// </summary>
        private static readonly int INSERTION_SORT_SIZE = 16;

        /// <summary>
        /// http://h2database.googlecode.com/svn/trunk/h2/src/tools/org/h2/dev/sort/InPlaceStableQuicksort.java
        /// This is a stable version of quicksort. It differs from traditional quicksort in that
        /// instead of swapping elements that need to be pivotted, runs of elements are rotated around
        /// to maintain stability.
        /// </summary>
        public static void Sort<T>(T[] array, SortType sortType) where T : IComparable
        {
            int length = Math.Max(Convert.ToInt32(100 * Math.Log(array.Length)), TEMP_SIZE);
            length = Math.Min(array.Length, length);
            T[] temp = new T[length];
            Sort(array, temp, sortType, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, T[] temp, SortType sortType, int from, int to) where T : IComparable
        {
            while (to > from)
            {
                if (to - from < INSERTION_SORT_SIZE)
                {
                    BinaryInsertionSort.Sort(array, sortType, from, to);
                    return;
                }

                T pivot = SelectPivot(array, temp, sortType, from, to);
                int middle = Partition(array, temp, sortType, pivot, from, to);
                // if 'middle' is larger than the 'to' index, then all elements are smaller or equal to the pivot.
                if (middle > to)
                {
                    // reset temp array values
                    SelectPivot(array, temp, sortType, from, to);
                    // reset pivot
                    pivot = array[to];
                    // reset partitioning index
                    middle = Partition(array, temp, sortType, pivot, from, to);
                    if (middle > to)
                    {
                        middle--;
                    }
                }
                Sort(array, temp, sortType, from, middle - 1);
                from = middle;
            }
        }

        /// <summary>
        /// Move all elements that are bigger than the pivot to the end of the list,
        /// and return the partitioning index. The partitioning index is the start
        /// index of the range where all elements are larger than the pivot. If the
        /// partitioning index is larger than the 'to' index, then all elements are
        /// smaller or equal to the pivot.
        /// </summary>
        private static int Partition<T>(T[] array, T[] temp, SortType sortType, T pivot, int from, int to) where T : IComparable
        {
            if (to - from < temp.Length)
            {
                return PartitionSmall(array, temp, sortType, pivot, from, to);
            }

            int middle = (from + to + 1) / 2;
            int left = Partition(array, temp, sortType, pivot, from, middle - 1);
            int right = Partition(array, temp, sortType, pivot, middle, to);
            SwapBlocks(array, temp, left, middle, right - 1);
            return left + right - middle;
        }

        /// <summary>
        /// Partition a small block using the temporary array. This will speed up partitioning.
        /// </summary>
        private static int PartitionSmall<T>(T[] array, T[] temp, SortType sortType, T pivot, int from, int to) where T : IComparable
        {
            int tempIndex = 0, dataIndex = from;
            for (int i = from; i <= to; i++)
            {
                T x = array[i];
                if (Common.IsInOrder(x, pivot, sortType))
                {
                    if (tempIndex > 0)
                    {
                        array[dataIndex] = x;
                    }
                    dataIndex++;
                }
                else
                {
                    temp[tempIndex++] = x;
                }
            }
            if (tempIndex > 0)
            {
                Array.Copy(temp, 0, array, dataIndex, tempIndex);
            }
            return dataIndex;
        }

        /// <summary>
        /// Swap the elements of two blocks in the data array. Both blocks are next
        /// to each other(the second block starts just after the first block ends).
        /// </summary>
        private static void SwapBlocks<T>(T[] array, T[] temp, int from, int middle, int to)
        {
            int len1 = middle - from, len2 = to - middle + 1;
            if (len1 == 0 || len2 == 0)
            {
                return;
            }
            if (len1 < temp.Length)
            {
                Array.Copy(array, from, temp, 0, len1);
                Array.Copy(array, middle, array, from, len2);
                Array.Copy(temp, 0, array, from + len2, len1);
                return;
            }
            else if (len2 < temp.Length)
            {
                Array.Copy(array, middle, temp, 0, len2);
                Array.Copy(array, from, array, from + len2, len1);
                Array.Copy(temp, 0, array, from, len2);
                return;
            }
            Common.ReversalBlockSwap(array, from, middle, to);
        }

        /// <summary>
        /// Select a pivot.
        /// To ensure a good pivot is selected, the median element of a sample of data is calculated.
        /// </summary>
        /// <returns>Pivot.</returns>
        private static T SelectPivot<T>(T[] array, T[] temp, SortType sortType, int from, int to) where T : IComparable
        {
            int count = Convert.ToInt32(6 * Math.Log10(to - from));
            count = Math.Min(count, temp.Length);
            int step = (to - from) / count;
            for (int i = from, j = 0; i < to; i += step, j++)
            {
                temp[j] = array[i];
            }
            T pivot = SelectPivot(temp, sortType, 0, count, count / 2);
            return pivot;
        }

        /// <summary>
        /// Select the specified element.
        /// </summary>
        /// <returns>The specified element.</returns>
        private static T SelectPivot<T>(T[] array, SortType sortType, int from, int to, int middle) where T : IComparable
        {
            while (true)
            {
                int pivotIndex = (to + from) / 2;
                int pivotNewIndex = SelectPartition(array, sortType, from, to, pivotIndex);
                int pivotDistance = pivotNewIndex - from + 1;
                if (pivotDistance == middle)
                {
                    return array[pivotNewIndex];
                }
                else if (pivotDistance > middle)
                {
                    to = pivotNewIndex - 1;
                }
                else
                {
                    middle = middle - pivotDistance;
                    from = pivotNewIndex + 1;
                }
            }
        }

        /// <summary>
        /// Partition the elements to select an element.
        /// </summary>
        /// <returns>New pivot index.</returns>
        private static int SelectPartition<T>(T[] array, SortType sortType, int from, int to, int pivotIndex) where T : IComparable
        {
            T pivotValue = array[pivotIndex];
            // Move pivot element to the end.
            Common.Swap(ref array[pivotIndex], ref array[to]);
            // Go through all elements, move smaller/greater elements than pivot element to left.
            int storeIndex = from;
            for (int i = from; i <= to; i++)
            {
                if (!Common.IsInOrder(array[i], pivotValue, sortType))
                {
                    if (i!=storeIndex)
                    {
                        Common.Swap(ref array[storeIndex], ref array[i]);
                    }
                    storeIndex++;
                }
            }
            // Move pivot element to the right location.
            Common.Swap(ref array[to], ref array[storeIndex]);
            // Return pivot new index.
            return storeIndex;
        }
    }
}
