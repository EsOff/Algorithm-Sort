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
                        ReversalBlockSwap(array, binaryInTopHalf, middle, binaryInBottomHalf);
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

        #region Naive merge method
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
        #endregion

        #region Reversal block swaping
        private static void Reverse<T>(T[] array, int from, int to)
        {
            while (from < to)
            {
                Common.Swap(ref array[from++], ref array[to--]);
            }
        }

        private static void ReversalBlockSwap<T>(T[] array, int from, int middle, int to)
        {
            Reverse(array, from, middle);
            Reverse(array, middle + 1, to);
            Reverse(array, from, to);
        }
        #endregion

        #region Juggling block swaping
        /// <summary>
        /// greatest common divisor
        /// </summary>
        private static int GCD(int m, int n)
        {
            if (m == 0)
            {
                return n;
            }
            if (n == 0)
            {
                return m;
            }
            while (m != n)
            {
                if (m > n)
                {
                    m -= n;
                }
                else
                {
                    n -= m;
                }
            }
            return m;
        }

        /// <summary>
        /// TODO: need to update it to adapt non-zero based block swap.
        /// </summary>
        private static void JugglingBlockSwap<T>(T[] array, int from, int middle, int to)
        {
            int u = middle - from + 1;
            int v = to - middle;
            if (u <= 0 || v <= 0)
            {
                return;
            }

            int rotationDistance = u;
            int n = to - from + 1;
            int gcd = GCD(rotationDistance, n);

            for (int i = from; i < from + gcd; i++)
            {
                // move i-th value of block
                T temp = array[i];
                int j = i;
                while (true)
                {
                    int k = (j + rotationDistance);
                    if (k >= n)
                    {
                        k -= n;
                    }
                    if (k == i)
                    {
                        break;
                    }
                    array[j] = array[k];
                    j = k;
                }
                array[j] = temp;
            }
        }
        #endregion

        #region Gries and Mills block swapping
        private static void SwapBlock<T>(T[] array, int from, int to, int rotationLength)
        {
            for (int i = 0; i < rotationLength; i++)
            {
                Common.Swap(ref array[from++], ref array[to++]);
            }
        }

        /// <summary>
        /// 1.A is the left subarray, B is the right subarray - that is, the starting point is AB
        /// 2.If A is shorter, divide B into BL and BR, such that length of BR equals the length of A
        /// 3.Swap A and BR to change ABLBR into BRBLA
        /// 4.Else if A is longer than B,divide A into AL and AR, such that length of AL equals the length of B
        /// 5.Swap AL and B to change ALARB into BARAL
        /// 6.Recur on the two pieces of B(or A)
        /// 7.Once A and B are of equal lengths, swap A and B
        /// </summary>
        private static void GriesMillsBlockSwap<T>(T[] array, int from, int middle, int to)
        {
            int rotationDistance = middle - from + 1;
            int n = to - from + 1;
            if (rotationDistance == 0 || rotationDistance == n)
            {
                return;
            }

            int p = rotationDistance;
            int i = rotationDistance; // left  subarray A length
            int j = n - i;            // right subarray B length
            while (i != j)
            {
                if (i > j)
                {
                    SwapBlock(array, from + p - i, from + p, j);
                    i -= j;
                }
                else
                {
                    SwapBlock(array, from + p - i, from + p + j - i, i);
                    j -= i;
                }
            }
            SwapBlock(array, from + p - i, from + p, i);
        }
        #endregion
    }
}