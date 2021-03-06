﻿using System.Collections.Generic;
using System.Linq;
using Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphTests
{
   [TestClass]
   public class DijkstraShortestPathTests
   {
      [TestMethod]
      public void AssertCanSearch()
      {

         IGraph graph = new GraphAdjMatrix(new[] { 0, 1, 2, 3, 4 });
         graph.AddEdge(0, 1, 2);
         graph.AddEdge(1, 3, 1);
         graph.AddEdge(1, 4, 6);
         graph.AddEdge(2, 3, 2);
         graph.AddEdge(3, 4, 1);

         var dks = new DijkstraShortestPath(graph);
         var result = dks.CanFind(0, 4);
         Assert.IsTrue(result);



         var direction = dks.PathToGoal();
         Assert.AreEqual(4, direction[3]);
         Assert.AreEqual(3, direction[2]);
         Assert.AreEqual(1, direction[1]);
         Assert.AreEqual(0, direction[0]);
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


         var bfs = new DijkstraShortestPath(graph);
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

         var bfs = new DijkstraShortestPath(graph);
         var result = bfs.CanFind(0, 8);
         Assert.IsTrue(result);

         var direction = bfs.PathToGoal();
         Assert.AreEqual(8, direction[6]);
         Assert.AreEqual(5, direction[5]);
         Assert.AreEqual(4, direction[4]);
         Assert.AreEqual(3, direction[3]);
         Assert.AreEqual(2, direction[2]);
         Assert.AreEqual(1, direction[1]);
         Assert.AreEqual(0, direction[0]);
      }

      [TestMethod]
      public void AssertCanSearchShortestPathWithMultipleParents()
      {
         IGraph graph = new GraphAdjMatrix(new[] { 0, 1, 2, 3, 4, 5, 6 });
         graph.AddEdge(0, 1, 1);
         graph.AddEdge(0, 3, 3);
         graph.AddEdge(1, 2, 1);
         graph.AddEdge(2, 4, 1);
         graph.AddEdge(4, 6, 4);
         graph.AddEdge(3, 5, 3);
         graph.AddEdge(5, 6, 1);
         graph.AddEdge(3, 6, 5);

         var bfs = new DijkstraShortestPath(graph);
         var result = bfs.CanFind(0, 6);
         Assert.IsTrue(result);

         var direction = bfs.PathToGoal();

         Assert.AreEqual(0, direction[0]);
         Assert.AreEqual(3, direction[1]);
         Assert.AreEqual(5, direction[2]);
         Assert.AreEqual(6, direction[3]);
      }
   }

}
