using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
   public class GraphAdjMatrix : IGraph
   {
      private int[,] adjMatrix;
      private readonly List<int> vertices;
      private readonly Dictionary<Tuple<int, int>, int> edgeWeights;

      public GraphAdjMatrix(int[] vertices, bool isDirected = true)
      {
         this.vertices = vertices.ToList();
         adjMatrix = new int[NumberOfVertices, NumberOfVertices];
         edgeWeights = new Dictionary<Tuple<int, int>, int>(vertices.Length);
         IsDirected = isDirected;
      }

      public int NumberOfVertices => vertices.Count;
      public int GetEdgeWeight(int firstVertex, int secondVertex)
      {
         return edgeWeights[new Tuple<int, int>(firstVertex, secondVertex)];
      }

      public int NumberOfEdges { get; private set; }

      public void AddVertex()
      {
         //add next vertices
         vertices.Add(NumberOfVertices + 1);

         if (adjMatrix.GetUpperBound(1) < NumberOfVertices)
         {
            var temp = new int[NumberOfVertices * 2, NumberOfVertices * 2];
            for (int i = 0; i < NumberOfVertices - 1; i++)
            {
               for (int j = 0; j < NumberOfVertices - 1; j++)
               {
                  temp[i, j] = adjMatrix[i, j];
               }
            }

            adjMatrix = temp;
         }
      }

      //adds a directed edge
      public void AddEdge(int firstVertex, int secondVertex, int weight = 0)
      {
         if (firstVertex > NumberOfVertices || secondVertex > NumberOfVertices)
         {
            throw new IndexOutOfRangeException();
         }

         ConnectVertex(firstVertex, secondVertex, weight);

         if (!IsDirected)
         {
            ConnectVertex(secondVertex, firstVertex, weight);
         }
      }

      private void ConnectVertex(int firstVertex, int secondVertex, int weight)
      {
         if (adjMatrix[firstVertex, secondVertex] != 1)
         {
            adjMatrix[firstVertex, secondVertex] = 1;
            NumberOfEdges++;
            edgeWeights.Add(new Tuple<int, int>(firstVertex, secondVertex), weight);
         }
      }

      public List<int> GetNeighbours(int vertex)
      {
         var neighbours = new List<int>();

         for (int i = 0; i < NumberOfVertices; i++)
         {
            if (adjMatrix[vertex, i] == 1)
            {
               neighbours.Add(i);
            }
         }

         return neighbours;
      }

      public bool IsDirected { get; private set; }
   }
}