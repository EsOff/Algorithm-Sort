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
        /// <summary>
        /// To make sort algorithm stable, don't exchange 2 elements when they're equal.
        /// </summary>
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
    }
}
