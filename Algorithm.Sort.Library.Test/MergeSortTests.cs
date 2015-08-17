namespace Algorithm.Sort.Library.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class MergeSortTests
    {
        [TestMethod]
        public void SortByAscending()
        {
            MergeSort.Sort(Common.Array, SortType.Ascending);
            Assert.IsTrue(Common.IsSame(Common.Array, Common.SortedByAscendingArray));
        }

        [TestMethod]
        public void SortByDescending()
        {
            MergeSort.Sort(Common.Array, SortType.Descending);
            Assert.IsTrue(Common.IsSame(Common.Array, Common.SortedByDescendingArray));
        }
    }
}