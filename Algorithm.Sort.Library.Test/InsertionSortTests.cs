namespace Algorithm.Sort.Library.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InsertionSortTests
    {
        [TestMethod]
        public void SortByAscending()
        {
            InsertionSort.Sort(Common.Array, SortType.Ascending);
            Assert.IsTrue(Common.IsSame(Common.Array, Common.SortedByAscendingArray));
        }

        [TestMethod]
        public void SortByDescending()
        {
            InsertionSort.Sort(Common.Array, SortType.Descending);
            Assert.IsTrue(Common.IsSame(Common.Array, Common.SortedByDescendingArray));
        }
    }
}
