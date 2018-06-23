using Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphTests
{
   [TestClass]
   public class BreadthFirstSearchTests
   {
      [TestMethod]
      public void AssertCanSearch()
      {
         IGraph graph = new GraphAdjMatrix(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
         graph.AddEdge(0, 1);
         graph.AddEdge(1, 2);
         graph.AddEdge(2, 3);
         graph.AddEdge(3, 4);
         graph.AddEdge(4, 5);
         graph.AddEdge(5, 6);
         graph.AddEdge(5, 8);
         graph.AddEdge(6, 7);
         graph.AddEdge(7, 8);
         graph.AddEdge(8, 5);


         graph.AddEdge(0, 9);
         graph.AddEdge(9, 10);
         graph.AddEdge(10, 11);
         graph.AddEdge(11, 12);

         var bfs = new BreadthFirstSearch(graph);
         var result = bfs.CanFind(0, 12);
         Assert.IsTrue(result);
      }

      [TestMethod]
      public void AssertCanNotSearch()
      {
         IGraph graph = new GraphAdjMatrix(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
         graph.AddEdge(0, 1);
         graph.AddEdge(1, 2);
         graph.AddEdge(2, 3);
         graph.AddEdge(3, 4);
         graph.AddEdge(4, 5);
         graph.AddEdge(5, 6);
         graph.AddEdge(5, 8);
         graph.AddEdge(6, 7);
         graph.AddEdge(7, 8);
         graph.AddEdge(8, 5);


         graph.AddEdge(0, 9);
         graph.AddEdge(9, 10);
         graph.AddEdge(10, 11);


         var bfs = new BreadthFirstSearch(graph);
         var result = bfs.CanFind(0, 12);
         Assert.IsFalse(result);
      }

      [TestMethod]
      public void AssertCanSearchSomeWhereInMiddle()
      {
         IGraph graph = new GraphAdjMatrix(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
         graph.AddEdge(0, 1);
         graph.AddEdge(1, 2);
         graph.AddEdge(2, 3);
         graph.AddEdge(3, 4);
         graph.AddEdge(4, 5);
         graph.AddEdge(5, 6);
         graph.AddEdge(5, 8);
         graph.AddEdge(6, 7);
         graph.AddEdge(7, 8);
         graph.AddEdge(8, 5);


         graph.AddEdge(0, 9);
         graph.AddEdge(9, 10);
         graph.AddEdge(10, 11);
         graph.AddEdge(11, 12);

         var bfs = new BreadthFirstSearch(graph);
         var result = bfs.CanFind(0, 8);
         Assert.IsTrue(result);
      }
   }

}
