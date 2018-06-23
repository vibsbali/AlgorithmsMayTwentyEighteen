using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestProject")]
namespace StringSearchAlgorithms
{
   public class BoyerMooreHorspool
   {
      private readonly string backingStore;
      internal Dictionary<char, int> badMatchTable;
      private string wordToFind;

      public BoyerMooreHorspool(string backingStore)
      {
         this.backingStore = backingStore;
      }

      public bool Found(string wordToFind)
      {
         badMatchTable = new Dictionary<char, int>();
         this.wordToFind = wordToFind;

         for (int i = 0; i < wordToFind.Length; i++)
         {
            var charToAdd = wordToFind[i];
            if (badMatchTable.ContainsKey(charToAdd))
            {
               badMatchTable.Remove(charToAdd);
            }

            var maxLength = wordToFind.Length - 1;
            badMatchTable.Add(charToAdd, maxLength - i);
         }

         return Find();
      }

      private bool Find()
      {
         //Zero based index
         var i = wordToFind.Length - 1;
         while (i < backingStore.Length)
         {
            //If no match skip the length of word to find
            if (!badMatchTable.ContainsKey(backingStore[i]))
            {
               i = i + wordToFind.Length;
               continue;
            }
            //else if match is found
            else
            {
               var indexToSkip = badMatchTable[backingStore[i]];
               if (indexToSkip != 0)
               {
                  i = i + indexToSkip;
                  continue;
               }

               //otherwise find the number of elements 
               var numberOfComparisonsToDo = wordToFind.Length;
               var lastIndex = wordToFind.Length - 1;
               while (numberOfComparisonsToDo != 0 && i >= 0)
               {
                  if (backingStore[i] == wordToFind[lastIndex])
                  {
                     i--;
                     numberOfComparisonsToDo--;
                     lastIndex--;
                  }
                  else
                  {
                     //we have found that the elements do not match
                     i = i < wordToFind.Length - 1 ? wordToFind.Length + i: i;
                     break;
                  }
               }
               if (numberOfComparisonsToDo == 0)
               {
                  return true;
               }
            }

            
         }

         return false;
      }
   }
}
