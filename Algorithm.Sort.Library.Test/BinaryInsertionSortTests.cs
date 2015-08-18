namespace Algorithm.Sort.Library.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class BinaryInsertionSortTests
    {
        [TestMethod]
        public void SortByAscending()
        {
            BinaryInsertionSort.Sort(Common.Array, SortType.Ascending);
            Assert.IsTrue(Common.IsSame(Common.Array, Common.SortedByAscendingArray));
        }

        [TestMethod]
        public void SortByDescending()
        {
            BinaryInsertionSort.Sort(Common.Array, SortType.Descending);
            Assert.IsTrue(Common.IsSame(Common.Array, Common.SortedByDescendingArray));
        }
    }
}