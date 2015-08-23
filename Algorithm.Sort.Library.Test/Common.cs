namespace Algorithm.Sort.Library.Test
{
    public sealed class Common
    {
        public static int[] Array = { 2, 7, 9, 11, -5, 3, -1, 8, 6 };
        public static int[] SortedByAscendingArray = { -5, -1, 2, 3, 6, 7, 8, 9, 11 };
        public static int[] SortedByDescendingArray = { 11, 9, 8, 7, 6, 3, 2, -1, -5 };

        public static bool IsSame(int[] a, int[] b)
        {
            bool result = true;
            if (a.Length == b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }
    }
}