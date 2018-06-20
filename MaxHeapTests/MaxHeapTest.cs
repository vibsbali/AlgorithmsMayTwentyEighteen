using System.Collections.Generic;
using System.Linq;
using HeapDataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxHeapTests
{
   [TestClass]
   public class MaxHeapTest
   {
      [TestMethod]
      public void Add8_6_5_3_4()
      {
         var maxHeap = new MaxHeap<int>();
         maxHeap.Add(8);
         maxHeap.Add(6);
         maxHeap.Add(5);
         maxHeap.Add(3);
         maxHeap.Add(4);

         Assert.AreEqual(5, maxHeap.Count);
      }

      [TestMethod]
      public void Add8_6_5_3_4_10()
      {
         var maxHeap = new MaxHeap<int>();
         maxHeap.Add(8);
         maxHeap.Add(6);
         maxHeap.Add(5);
         maxHeap.Add(3);
         maxHeap.Add(4);
         maxHeap.Add(10);

         Assert.AreEqual(6, maxHeap.Count);

         var top = maxHeap.Peek();
         Assert.AreEqual(10, top);
      }

      [TestMethod]
      public void Add_Duplicate_Max_Values_8_6_10_3_4_10_5()
      {
         var maxHeap = new MaxHeap<int>();
         maxHeap.Add(8);
         maxHeap.Add(6);
         maxHeap.Add(10);
         maxHeap.Add(3);
         maxHeap.Add(4);
         maxHeap.Add(10);
         maxHeap.Add(5);

         Assert.AreEqual(7, maxHeap.Count);

         var top = maxHeap.Peek();
         Assert.AreEqual(10, top);
      }

      [TestMethod]
      public void Add_One_Element_And_Remove_It()
      {
         var maxHeap = new MaxHeap<int>();
         maxHeap.Add(8);

         Assert.AreEqual(1, maxHeap.Count);

         var top = maxHeap.RemoveTop();
         Assert.AreEqual(8, top);

         Assert.AreEqual(0, maxHeap.Count);
      }

      [TestMethod]
      public void Add_Two_Elements_And_Remove_Top()
      {
         var maxHeap = new MaxHeap<int>();
         maxHeap.Add(8);
         maxHeap.Add(10);

         Assert.AreEqual(2, maxHeap.Count);

         var top = maxHeap.RemoveTop();
         Assert.AreEqual(10, top);

         Assert.AreEqual(1, maxHeap.Count);
      }

      [TestMethod]
      public void Add_Two_Elements_And_Remove_Both()
      {
         var maxHeap = new MaxHeap<int>();
         maxHeap.Add(8);
         maxHeap.Add(10);

         Assert.AreEqual(2, maxHeap.Count);

         var top = maxHeap.RemoveTop();
         Assert.AreEqual(10, top);

         Assert.AreEqual(1, maxHeap.Count);

         top = maxHeap.RemoveTop();
         Assert.AreEqual(8, top);

         Assert.AreEqual(0, maxHeap.Count);
      }

      [TestMethod]
      public void Add_MultipleValues_Remove_One_By_One()
      {
         var maxHeap = new MaxHeap<int>();
         var list = new List<int>
         {
            8,
            6,
            10,
            3,
            4,
            10,
            5
         };

         foreach (var i in list)
         {
            maxHeap.Add(i);
         }

         list.Sort();

         var index = list.Count - 1;

         while (maxHeap.Count != 0)
         {
            var top = maxHeap.RemoveTop();
            Assert.AreEqual(list[index--], top);
         }

         Assert.AreEqual(0, maxHeap.Count);
      }

   }
}
