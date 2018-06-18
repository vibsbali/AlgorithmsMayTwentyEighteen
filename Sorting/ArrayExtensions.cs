using System;

namespace Sorting
{
   public static class ArrayExtensions
   {
      public static void Swap<T>(this T[] arrayToBeSorted, int i, int j)
      {
         var temp = arrayToBeSorted[j];
         arrayToBeSorted[j] = arrayToBeSorted[i];
         arrayToBeSorted[i] = temp;
      }

      public static bool IsSorted<T>(this T[] array)
         where T : IComparable<T>
      {
        
         for (int i = 0; i < array.Length - 1; i++)
         {
            if (array[i + 1].CompareTo(array[i]) < 0)
            {
               return false;
            }
         }

         return true;
      }
   }
}