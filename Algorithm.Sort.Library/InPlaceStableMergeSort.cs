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
                Merge(array, sortType, from, middle, to);
            }
        }

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

        private static void JugglingBlockSwap<T>(T[] array, int from, int middle, int to)
        {
            int u = middle - from + 1;
            int v = to - middle;

            if (u <= 0 || v <= 0)
            {
                return;
            }
            int rotdist = middle - from + 1;
            int n = to - from + 1;
            int gcd_rotdist_n = GCD(rotdist, n);

            for (int i = 0; i < gcd_rotdist_n; i++)
            {
                // move i-th value of block
                T temp = array[i];
                int j = i;
                while (true)
                {
                    int k = j + rotdist;
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
        private static void SwapBlock<T>(T[] array, int from, int middle, int to)
        {
            for (int i = 0; i < middle; i++)
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
            int rotation_distance = middle - from + 1;
            int n = to - from + 1;
            if (rotation_distance == 0 || rotation_distance == n)
            {
                return;
            }

            int p = rotation_distance;
            int i = rotation_distance;
            int j = n - i;
            while (i != j)
            {
                if (i > j)
                {
                    SwapBlock(array, p - i, p, j);
                    i -= j;
                }
                else
                {
                    SwapBlock(array, p - i, p + j - i, i);
                    j -= i;
                }
            }
            SwapBlock(array, p - i, p, i);
        }
        #endregion
    }
}