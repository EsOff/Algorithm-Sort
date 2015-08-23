namespace Algorithm.Sort.Library.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class InPlaceStableMergeSortTests
    {
        [TestMethod]
        public void InPlaceStableMergeSortByAscedingTest()
        {
            InPlaceStableMergeSort.Sort(Common.Array, SortType.Ascending);
            Assert.IsTrue(Common.IsSame(Common.Array, Common.SortedByAscendingArray));
        }

        [TestMethod]
        public void InPlaceStableMergeSortByDescedingTest()
        {
            InPlaceStableMergeSort.Sort(Common.Array, SortType.Descending);
            Assert.IsTrue(Common.IsSame(Common.Array, Common.SortedByDescendingArray));
        }
    }
}