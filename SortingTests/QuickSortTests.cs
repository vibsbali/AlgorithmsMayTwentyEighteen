using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace SortingTests
{
    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        public void SingleDigitArrayAssertIsSorted()
        {
           var array = new[] {1};
           var mergeSort = new QuickSort<int>(array);

           mergeSort.Sort();
           Assert.IsTrue(array.IsSorted());
        }

       [TestMethod]
       public void TwoElementsInSortedOrderAssertIsSorted()
       {
          var array = new[] { 1, 2 };
          var mergeSort = new QuickSort<int>(array);

          mergeSort.Sort();
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
          var mergeSort = new QuickSort<int>(array);

          mergeSort.Sort();
          Assert.IsTrue(array.IsSorted());
       }

       [TestMethod]
       public void RandomArraySortItAndAssertIsSorted()
       {
          var array = new[] { 54, 26, 93,17, 77, 31, 44, 55, 20 };
          var mergeSort = new QuickSort<int>(array);

          mergeSort.Sort();
          Assert.IsTrue(array.IsSorted());
       }

   }
}
