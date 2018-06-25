using System;
using System.Collections.Generic;

namespace Graphs
{
   public class GraphAdjList : IGraph
   {
      private readonly Dictionary<int, List<int>> adjList;

      private readonly Dictionary<Tuple<int, int>, int> edgeWeights;

      public GraphAdjList(int[] vertices, bool isDirected = true)
      {
         adjList = new Dictionary<int, List<int>>(vertices.Length);
         edgeWeights = new Dictionary<Tuple<int, int>, int>(vertices.Length);
         foreach (var vertex in vertices)
         {
            adjList[vertex] = new List<int>();
         }

         NumberOfVertices = adjList.Count;
         IsDirected = isDirected;
      }

      public int NumberOfVertices { get; private set; }
      public int GetEdgeWeight(int firstVertex, int secondVertex)
      {
         return edgeWeights[new Tuple<int, int>(firstVertex, secondVertex)];
      }

      public int NumberOfEdges { get; private set; }
      public void AddVertex()
      {
         adjList.Add(++NumberOfVertices, new List<int>());
      }

      public void AddEdge(int firstVertex, int secondVertex, int weight)
      {
         if (firstVertex > NumberOfVertices || secondVertex > NumberOfVertices)
         {
            throw new InvalidOperationException();
         }

         if (!adjList[firstVertex].Contains(secondVertex))
         {
            ConnectVertex(firstVertex, secondVertex, weight);

            if (!IsDirected)
            {
               ConnectVertex(secondVertex, firstVertex, weight);
            }
         }
      }

      private void ConnectVertex(int firstVertex, int secondVertex, int weight)
      {
         adjList[firstVertex].Add(secondVertex);
         ++NumberOfEdges;
         edgeWeights.Add(new Tuple<int, int>(firstVertex, secondVertex), weight);
      }

      public List<int> GetNeighbours(int vertex)
      {
         return adjList[vertex];
      }

      public bool IsDirected { get; private set; }
   }
}