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
            int compareValue = a.CompareTo(b);

            bool result = false;

            if (sortType == SortType.Ascending)
            {
                if (compareValue != 1)
                {
                    result = true;
                }
            }
            else if (sortType == SortType.Descending)
            {
                if (compareValue != -1)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
