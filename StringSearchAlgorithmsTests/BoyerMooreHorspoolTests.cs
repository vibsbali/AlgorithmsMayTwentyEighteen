using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringSearchAlgorithms;

namespace StringSearchAlgorithmsTests
{
    [TestClass]
    public class BoyerMooreHorspoolTests
    {
        [TestMethod]
        public void CreateStringWithMatchingCharactersAtEnd()
        {
           var message = "we have found the truth";
           var wordToFind = "truth";

           var bmhp = new BoyerMooreHorspool(message);
           var result = bmhp.Found(wordToFind);

           Assert.IsTrue(result);
        }

       [TestMethod]
       public void CreateStringWithMatchingCharactersInMiddle()
       {
          var message = "we have found truth in all";
          var wordToFind = "truth";

          var bmhp = new BoyerMooreHorspool(message);
          var result = bmhp.Found(wordToFind);

          Assert.IsTrue(result);
       }

       [TestMethod]
       public void CreateStringWithMatchingCharactersAtStart()
       {
          var message = "truth is everywhere";
          var wordToFind = "truth";

          var bmhp = new BoyerMooreHorspool(message);
          var result = bmhp.Found(wordToFind);

          Assert.IsTrue(result);
       }

       [TestMethod]
       public void CreateStringWithNoMatchingCharacters()
       {
          var message = "thruth is nowhere because it is miss spelled";
          var wordToFind = "truth";

          var bmhp = new BoyerMooreHorspool(message);
          var result = bmhp.Found(wordToFind);

          Assert.IsFalse(result);
       }

       [TestMethod]
       public void CreateStringWithNoMatchingCharactersSecond()
       {
          var message = "hruth is nowhere because it is miss spelled";
          var wordToFind = "truth";

          var bmhp = new BoyerMooreHorspool(message);
          var result = bmhp.Found(wordToFind);

          Assert.IsFalse(result);
       }
   }
}
