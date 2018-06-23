using System.Collections.Generic;
using System.Linq;

namespace Tries
{
   public class Trie
   {
      private readonly int _radix;
      public int Count { get; private set; }

      //Creates a base level node
      private readonly TrieNode Head;

      public Trie(int radix)
      {
         _radix = radix;
         Head = new TrieNode(radix);
      }

      public void Add(string word)
      {
         var wordToAdd = word.ToLower();
         AddWord(wordToAdd, 0, Head);
         ++Count;
      }

      private void AddWord(string wordToAdd, int i, TrieNode node)
      {
         while (true)
         {
            var charToAdd = wordToAdd[i];

            if (node.Nodes[charToAdd] == null)
            {
               node.Nodes[charToAdd] = new TrieNode(_radix);
            }

            if (i == wordToAdd.Length - 1)
            {
               node.Nodes[charToAdd].Value = wordToAdd;
               return;
            }

            i++;
            node = node.Nodes[charToAdd];
         }
      }

      public List<string> FindWords(string partWord)
      {
         TrieNode startingNode = GetStartingNode(partWord);
         var listOfWordsToReturn = new List<string>();
         var nodes = new Queue<TrieNode>();
         nodes.Enqueue(startingNode);

         while (nodes.Count > 0)
         {
            var currentNode = nodes.Dequeue();
            foreach (var node in currentNode.Nodes.Where(n => n != null))
            {
               nodes.Enqueue(node);
               if (!string.IsNullOrWhiteSpace(node.Value))
               {
                  listOfWordsToReturn.Add(node.Value);
               }
            }
         }

         return listOfWordsToReturn;
      }

      private TrieNode GetStartingNode(string partWord)
      {
         var index = 0;
         var currentNode = Head;
         while (index != partWord.Length - 1)
         {
            if (currentNode == null)
            {
               return null;
            }

            currentNode = currentNode.Nodes[partWord.ToLower()[index]];
            ++index;

         }

         return currentNode;
      }
   }

}
