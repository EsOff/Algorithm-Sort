namespace Algorithm.Sort.Library.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class InPlaceStableQuickSortTests
    {
        [TestMethod]
        public void BubbleSortByAscendingTest()
        {
            int testArraySize = 10000;
            int[] inputArray = new int[testArraySize];
            int[] expectedArray = new int[testArraySize];
            Random random = new Random();
            for (int i = 0; i < testArraySize; i++)
            {
                inputArray[i] = random.Next(-10000, 10000);
                expectedArray[i] = inputArray[i];
            }
            Array.Sort(expectedArray);
            InPlaceStableQuickSort.Sort(inputArray, SortType.Ascending);
            Assert.IsTrue(Common.IsSame(inputArray, expectedArray));
        }

        [TestMethod]
        public void BubbleSortByDescendingTest()
        {
            int testArraySize = 10000;
            int[] inputArray = new int[testArraySize];
            int[] expectedArray = new int[testArraySize];
            Random random = new Random();
            for (int i = 0; i < testArraySize; i++)
            {
                inputArray[i] = random.Next(-10000, 10000);
                expectedArray[i] = inputArray[i];
            }
            Array.Sort(expectedArray);
            Array.Reverse(expectedArray);
            InPlaceStableQuickSort.Sort(Common.Array, SortType.Descending);
            Assert.IsTrue(Common.IsSame(inputArray, expectedArray));
        }
    }
}