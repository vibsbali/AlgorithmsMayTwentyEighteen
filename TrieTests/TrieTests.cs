using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tries;

namespace TrieTests
{
    [TestClass]
    public class TrieTests
    {
        [TestMethod]
        public void AddFourWordAssertCountTwo()
        {
           var trie = new Trie(256);
           trie.Add("Hello");
           trie.Add("Hell");
           trie.Add("World");
           trie.Add("I");

          Assert.AreEqual(4, trie.Count);
      }

       [TestMethod]
       public void AddFourWordSearchForSubstringHellAssertBothHelloAndHellAreFound()
       {
          var trie = new Trie(256);
          trie.Add("Hello");
          trie.Add("Hell");
          trie.Add("World");
          trie.Add("I");

          Assert.AreEqual(4, trie.Count);

          var listOfWords = trie.FindWords("Hel");

          Assert.AreEqual(2, listOfWords.Count);
          Assert.IsTrue(listOfWords.Contains("Hello".ToLower()));
          Assert.IsTrue(listOfWords.Contains("Hell".ToLower()));
       }
   }
}
