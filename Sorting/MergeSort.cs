using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
   public class MergeSort<T>
      where T : IComparable<T>
   {
      private readonly T[] arrayToBeSorted;

      public MergeSort(T[] arrayToBeSorted)
      {
         this.arrayToBeSorted = arrayToBeSorted;
      }

      public void Sort()
      {
         SortRecursively(arrayToBeSorted);
      }

      private void SortRecursively(T[] array)
      {
         if (array.Length <= 1)
         {
            return;
         }

         var mid = array.Length / 2;
         var leftArray = new T[mid];
         var rightArray = new T[array.Length - mid];

         Array.Copy(array, 0, leftArray, 0, leftArray.Length);
         Array.Copy(array, mid, rightArray, 0, rightArray.Length);

         SortRecursively(leftArray);
         SortRecursively(rightArray);

         Merge(array, leftArray, rightArray);
      }

      private void Merge(T[] auxArray, T[] leftArray, T[] rightArray)
      {
         var remaining = auxArray.Length;
         var leftIndex = 0;
         var rightIndex = 0;
         var startingIndex = 0;

         while (remaining > 0)
         {
            if (leftIndex >= leftArray.Length)
            {
               auxArray[startingIndex++] = rightArray[rightIndex++];
            }
            else if (rightIndex >= rightArray.Length)
            {
               auxArray[startingIndex++] = leftArray[leftIndex++];
            }
            else
            {

               if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) < 0)
               {
                  auxArray[startingIndex++] = leftArray[leftIndex++];
               }
               else
               {
                  auxArray[startingIndex++] = rightArray[rightIndex++];
               }
            }

            --remaining;
         }
      }
   }
}