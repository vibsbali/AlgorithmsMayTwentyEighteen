using System;
using System.Collections.Generic;

namespace Graphs
{
   public class GraphAdjList : IGraph
   {
      private readonly Dictionary<int, List<int>> adjList;
      public GraphAdjList(int[] vertices)
      {
         adjList = new Dictionary<int, List<int>>(vertices.Length);
         foreach (var vertex in vertices)
         {
            adjList[vertex] = new List<int>();
         }

         NumberOfVertices = adjList.Count;
      }

      public int NumberOfVertices { get; private set; }
      public int NumberOfEdges { get; private set; }
      public void AddVertex()
      {
         adjList.Add(++NumberOfVertices, new List<int>());
      }

      public void AddEdge(int firstVertex, int secondVertex)
      {
         if (firstVertex > NumberOfVertices || secondVertex > NumberOfVertices)
         {
            throw new InvalidOperationException();
         }

         if (!adjList[firstVertex].Contains(secondVertex))
         {
            adjList[firstVertex].Add(secondVertex);
            ++NumberOfEdges;
         }
      }

      public List<int> GetNeighbours(int vertex)
      {
         return adjList[vertex];
      }
   }
}