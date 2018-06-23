namespace Tries
{
   public class TrieNode
   {
      public TrieNode[] Nodes { get; private set; }

      public TrieNode(int radix)
      {
         Nodes = new TrieNode[radix];
      }

      public string Value { get; set; }
   }
}