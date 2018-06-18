using BinarySearchTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTreeTests
{
   [TestClass]
   public class BSTTests
   {
      [TestMethod]
      public void EmptyTreeAssertCountZero()
      {
         var bst = new BinaryTree<int>();
         Assert.AreEqual(0, bst.Count);
      }

      [TestMethod]
      public void TreeAdd500AssertCountOneHeadValue500()
      {
         var bst = new BinaryTree<int>();
         bst.Add(500);

         Assert.AreEqual(1, bst.Count);
         Assert.AreEqual(500, bst.Head.Value);
      }

      [TestMethod]
      public void TreeAdd7ElementsAssertItemsInRow()
      {
         var bst = new BinaryTree<int>();
         var collectionOfItems = new[] { 500, 250, 750, 125, 275, 625, 875 };

         foreach (var collectionOfItem in collectionOfItems)
         {
            bst.Add(collectionOfItem);
         }

         using (var enumerator = bst.GetEnumerator())
         {

            foreach (var t in collectionOfItems)
            {
               enumerator.MoveNext();
               var item = enumerator.Current;
               Assert.AreEqual(t, item);

            }
         }
      }

      [TestMethod]
      public void Add7ItemsSearchForExistingItemAssertContainsTrue()
      {
         var bst = new BinaryTree<int>();
         var collectionOfItems = new[] { 500, 250, 750, 125, 275, 625, 875 };
         foreach (var collectionOfItem in collectionOfItems)
         {
            bst.Add(collectionOfItem);
         }

         Assert.IsTrue(bst.Contains(275));

      }

      [TestMethod]
      public void Add7ItemsSearchForNonExistingItemAssertContainsFalse()
      {
         var bst = new BinaryTree<int>();
         var collectionOfItems = new[] { 500, 250, 750, 125, 275, 625, 875 };
         foreach (var collectionOfItem in collectionOfItems)
         {
            bst.Add(collectionOfItem);
         }

         Assert.IsFalse(bst.Contains(900));
      }

      [TestMethod]
      public void AddOneItemAndRemoveAssertCountZeroHeadNull()
      {
         var bst = new BinaryTree<int>();
         bst.Add(500);

         bst.Remove(500);

         Assert.AreEqual(0, bst.Count);
         Assert.IsNull(bst.Head);
      }

      [TestMethod]
      public void AddThreeItemsRemoveTailOnLeftAssertLeftNullRightOk()
      {
         var bst = new BinaryTree<int>();
         bst.Add(500);
         bst.Add(250);
         bst.Add(750);

         bst.Remove(250);

         Assert.AreEqual(2, bst.Count);
         Assert.AreEqual(500, bst.Head.Value);
         Assert.AreEqual(750, bst.Head.Right.Value);
         Assert.IsNull(bst.Head.Left);
      }

      [TestMethod]
      public void AddThreeItemsRemoveTailOnRightAssertRightNullLeftOk()
      {
         var bst = new BinaryTree<int>();
         bst.Add(500);
         bst.Add(250);
         bst.Add(750);

         bst.Remove(750);

         Assert.AreEqual(2, bst.Count);
         Assert.AreEqual(500, bst.Head.Value);
         Assert.AreEqual(250, bst.Head.Left.Value);
         Assert.IsNull(bst.Head.Right);
      }

      [TestMethod]
      public void AddFiveItemsRemoveItemOnLeftOfHead()
      {
         var bst = new BinaryTree<int>();
         bst.Add(500);
         bst.Add(250);
         bst.Add(750);
         bst.Add(125);
         bst.Add(625);

         bst.Remove(250);

         Assert.AreEqual(4, bst.Count);
         Assert.AreEqual(500, bst.Head.Value);
         Assert.AreEqual(125, bst.Head.Left.Value);
         Assert.AreEqual(750, bst.Head.Right.Value);
         Assert.AreEqual(625, bst.Head.Right.Left.Value);

         Assert.IsNull(bst.Head.Left.Left);
         Assert.IsNull(bst.Head.Left.Right);
      }

      [TestMethod]
      public void AddFiveItemsRemoveItemOnRightOfHead()
      {
         var bst = new BinaryTree<int>();
         bst.Add(500);
         bst.Add(250);
         bst.Add(750);
         bst.Add(125);
         bst.Add(625);

         bst.Remove(750);

         Assert.AreEqual(4, bst.Count);
         Assert.AreEqual(500, bst.Head.Value);
         Assert.AreEqual(250, bst.Head.Left.Value);
         Assert.AreEqual(125, bst.Head.Left.Left.Value);

         Assert.AreEqual(625, bst.Head.Right.Value);
         

         Assert.IsNull(bst.Head.Right.Left);
         Assert.IsNull(bst.Head.Right.Right);
      }

      [TestMethod]
      public void TestItemToRemoveHasRightWhichHasNoLeftChild_ItemToRemove_Left_Of_Parent()
      {
         var bst = new BinaryTree<int>();
         var collectionOfItems = new[] { 500, 250, 750, 125, 275, 625, 875, 300, 1000 };
         foreach (var collectionOfItem in collectionOfItems)
         {
            bst.Add(collectionOfItem);
         }

         bst.Remove(250);

         Assert.AreEqual(8, bst.Count);
         Assert.AreEqual(500, bst.Head.Value);
         Assert.AreEqual(275, bst.Head.Left.Value);
         Assert.AreEqual(125, bst.Head.Left.Left.Value);
         Assert.AreEqual(300, bst.Head.Left.Right.Value);

         Assert.AreEqual(750, bst.Head.Right.Value);
         Assert.AreEqual(625, bst.Head.Right.Left.Value);
         Assert.AreEqual(875, bst.Head.Right.Right.Value);
         Assert.AreEqual(1000, bst.Head.Right.Right.Right.Value);


         Assert.IsNull(bst.Head.Left.Right.Left);
        
      }

      [TestMethod]
      public void TestItemToRemoveHasRightWhichHasNoLeftChild_ItemToRemove_Right_Of_Parent()
      {
         var bst = new BinaryTree<int>();
         var collectionOfItems = new[] { 500, 250, 750, 125, 275, 625, 875, 300, 1000 };
         foreach (var collectionOfItem in collectionOfItems)
         {
            bst.Add(collectionOfItem);
         }

         bst.Remove(750);

         Assert.AreEqual(8, bst.Count);
         Assert.AreEqual(500, bst.Head.Value);
         Assert.AreEqual(250, bst.Head.Left.Value);
         Assert.AreEqual(125, bst.Head.Left.Left.Value);
         Assert.AreEqual(275, bst.Head.Left.Right.Value);
         Assert.AreEqual(300, bst.Head.Left.Right.Right.Value);

         Assert.AreEqual(875, bst.Head.Right.Value);
         Assert.AreEqual(625, bst.Head.Right.Left.Value);
        
         Assert.AreEqual(1000, bst.Head.Right.Right.Value);
         
      }

      [TestMethod]
      public void TestItemToRemoveHasRightWhichHasLeftChild_Removing_Head()
      {
         var bst = new BinaryTree<int>();
         var collectionOfItems = new[] { 500, 250, 750, 125, 275, 625, 875, 300, 1000 };
         foreach (var collectionOfItem in collectionOfItems)
         {
            bst.Add(collectionOfItem);
         }

         bst.Remove(500);

         Assert.AreEqual(8, bst.Count);
         Assert.AreEqual(625, bst.Head.Value);

         Assert.AreEqual(250, bst.Head.Left.Value);
         Assert.AreEqual(750, bst.Head.Right.Value);
         Assert.IsNull(bst.Head.Right.Left);
      }
   }


}
