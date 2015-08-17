namespace Algorithm.Sort.Library
{
    public enum OrderBy
    {
        Ascending = 0,
        Descending = 1
    }

    public class Order
    {
        /// <summary>
        /// Are a and b in order?
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public static bool IsInOrder(int a, int b, OrderBy orderBy)
        {
            if (orderBy == OrderBy.Ascending)
            {
                return a <= b;
            }
            else
            {
                return a >= b;
            }
        }
    }
}
