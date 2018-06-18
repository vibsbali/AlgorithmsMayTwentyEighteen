using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace SortingTests
{
    [TestClass]
    public class InsertionSortTests
    {
        [TestMethod]
        public void SingleDigitArrayAssertIsSorted()
        {
           var array = new[] {1};
           var insertionSort = new InsertionSort<int>(array);

           insertionSort.Sort();
           Assert.IsTrue(array.IsSorted());
        }

       [TestMethod]
       public void TwoElementsInSortedOrderAssertIsSorted()
       {
          var array = new[] { 1, 2 };
          var insertionSort = new InsertionSort<int>(array);

          insertionSort.Sort();
          Assert.IsTrue(array.IsSorted());
       }

       [TestMethod]
       public void TwoElementsInUnSortedOrderAssertIsNotSorted()
       {
          var array = new[] { 2, 1 };
          
          Assert.IsFalse(array.IsSorted());
       }

       [TestMethod]
       public void TwoElementsInUnSortedOrderSortItAndAssertIsSorted()
       {
          var array = new[] { 2, 1 };
          var insertionSort = new InsertionSort<int>(array);

          insertionSort.Sort();
          Assert.IsTrue(array.IsSorted());
       }

       [TestMethod]
       public void RandomArraySortItAndAssertIsSorted()
       {
          var array = new[] { 54, 26, 93,17, 77, 31, 44, 55, 20 };
          var insertionSort = new InsertionSort<int>(array);

          insertionSort.Sort();
          Assert.IsTrue(array.IsSorted());
       }

   }
}
