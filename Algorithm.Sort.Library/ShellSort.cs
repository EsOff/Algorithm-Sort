namespace Algorithm.Sort.Library
{
    using System;

    public class ShellSort
    {
        public static void Sort<T>(T[] array, SortType sortType) where T : IComparable
        {
            int n = array.Length;
            int[] steps = CalSteps(n);
            foreach (var step in steps)
            {
                for (int i = step; i < n; i++)
                {
                    // the following algorithm is insertion sort.
                    T key = array[i];
                    int j = i;
                    while (j >= step && !Common.IsInOrder(array[j - step], key, sortType))
                    {
                        array[j] = array[j - step];
                        j -= step;
                    }
                    array[j] = key;
                }
            }
        }

        /// <summary>
        /// Steps = Math.Pow(2, k) - 1.
        /// 0, 1, 3, 7, 15, 31 ...
        /// </summary>
        private static int[] CalSteps(int n)
        {
            int count = Convert.ToInt32(Math.Log(n + 1, 2));
            int[] steps = new int[count + 1];
            for (int i = count; i >= 0; i--)
            {
                steps[count - i] = Convert.ToInt32(Math.Pow(2, i)) - 1;
            }
            return steps;
        }
    }
}
