using System;
using System.Collections.Generic;
using Sorting;

namespace HeapDataStructure
{
   public class MaxHeap<T>
      where T : IComparable<T>
   {
      private List<T> backingStore { get; } = new List<T>();

      public int Count { get; private set; }

      public void Add(T item)
      {
         //add item to the end of the array
         backingStore.Add(item);
         Count++;

         //call reset to move the max to top of the array
         SwimUp(Count - 1);
      }

      private void SwimUp(int index)
      {
         var parentIndex = GetParentIndex(index);
         while (index != 0 && backingStore[index].CompareTo(backingStore[parentIndex]) > 0)
         {
            backingStore.Swap(index, parentIndex);
            index = parentIndex;
            parentIndex = GetParentIndex(parentIndex);
         }
      }

      public T RemoveTop()
      {
         var item = backingStore[0];
         --Count;

         //Swap the last item to first
         backingStore[0] = backingStore[Count];
         backingStore[Count] = default(T);

         SwimDown(0);
         return item;
      }

      private void SwimDown(int parentIndex)
      {
         if (parentIndex < Count)
         {
            //Get Max of left and right 
            var maxChildIndex = GetMaxChild(parentIndex);

            //If parent is equal to maxChild or parent is greater than or equal to max of children then heap property
            //is satisfied
            if (maxChildIndex == parentIndex || backingStore[parentIndex].CompareTo(backingStore[maxChildIndex]) >= 0)
            {
               return;
            }

            //Otherwise swap
            backingStore.Swap(maxChildIndex, parentIndex);
            SwimDown(maxChildIndex);
         }
      }

      private int GetMaxChild(int index)
      {
         var leftChild = GetLeftChild(index);
         var rightChild = GetRightChild(index);

         if (backingStore[rightChild].CompareTo(backingStore[leftChild]) >= 0)
         {
            return rightChild;
         }

         return leftChild;
      }

      private int GetParentIndex(int index)
      {
         var parentIndex = index == 0 ? 0 : ((index - 1) / 2);
         return parentIndex;
      }

      private int GetLeftChild(int index)
      {
         var potentialLeftIndex = (index * 2) + 1;

         //If going above bounds 0 based parentIndex
         if (potentialLeftIndex >= Count)
         {
            return index;
         }

         return potentialLeftIndex;
      }

      private int GetRightChild(int index)
      {
         var potentialRightIndex = (index * 2) + 2;

         //If going above bounds 0 based parentIndex
         if (potentialRightIndex >= Count)
         {
            return index;
         }

         return potentialRightIndex;
      }

      public T Peek()
      {
         return backingStore[0];
      }
   }
}
