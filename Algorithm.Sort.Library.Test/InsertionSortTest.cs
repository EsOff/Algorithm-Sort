namespace Algorithm.Sort.Library.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InsertionSortTest
    {
        private int[] array = { 2, 7, 9, 11, 3, 1, 8, 6 };
        private int[] sortedByAscendingArray = { 1, 2, 3, 6, 7, 8, 9, 11 };
        private int[] sortedByDescendingArray = { 11, 9, 8, 7, 6, 3, 2, 1 };

        [TestMethod]
        public void SortByAscending()
        {
            InsertionSort.Sort(array, OrderBy.Ascending);
            Assert.IsTrue(IsSame(array, sortedByAscendingArray));
        }

        [TestMethod]
        public void SortByDescending()
        {
            InsertionSort.Sort(array, OrderBy.Descending);
            Assert.IsTrue(IsSame(array, sortedByDescendingArray));
        }

        private bool IsSame(int[] a, int[] b)
        {
            bool result = false;
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
                result = true;
            }
            return result;
        }
    }
}
