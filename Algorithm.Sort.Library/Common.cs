namespace Algorithm.Sort.Library
{
    using System;

    public enum SortType
    {
        Ascending = 0,
        Descending = 1
    }

    public sealed class Common
    {
        public static bool IsInOrder<T>(T a, T b, SortType sortType) where T : IComparable
        {
            // < : -1
            // = : 0
            // > : 1
            int compareValue = a.CompareTo(b);

            bool result = false;

            if (sortType == SortType.Ascending)
            {
                // <= : -1 or 0
                if (compareValue != 1)
                {
                    result = true;
                }
            }
            else if (sortType == SortType.Descending)
            {
                // >= : 0 or 1
                if (compareValue != -1)
                {
                    result = true;
                }
            }

            return result;
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        #region Reversal block swaping
        public static void Reverse<T>(T[] array, int from, int to)
        {
            while (from < to)
            {
                Common.Swap(ref array[from++], ref array[to--]);
            }
        }

        /// <summary>
        /// Need pay attention "block scope" when using this method:
        /// Swap block [from, middle-1] with block [middle, to]
        /// </summary>
        public static void ReversalBlockSwap<T>(T[] array, int from, int middle, int to)
        {
            Reverse(array, from, middle - 1);
            Reverse(array, middle, to);
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
        public static void JugglingBlockSwap<T>(T[] array, int from, int middle, int to)
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
        public static void GriesMillsBlockSwap<T>(T[] array, int from, int middle, int to)
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
