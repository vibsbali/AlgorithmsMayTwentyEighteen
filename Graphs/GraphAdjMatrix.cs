using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
   public class GraphAdjMatrix : IGraph
   {
      private int[,] adjMatrix;
      private readonly List<int> vertices;

      public GraphAdjMatrix(int[] vertices)
      {
         this.vertices = vertices.ToList();
         adjMatrix = new int[NumberOfVertices, NumberOfVertices];
      }

      public int NumberOfVertices => vertices.Count;
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
      public void AddEdge(int firstVertex, int secondVertex)
      {
         if (firstVertex > NumberOfVertices || secondVertex > NumberOfVertices)
         {
            throw new IndexOutOfRangeException();
         }

         if (adjMatrix[firstVertex, secondVertex] != 1)
         {
            adjMatrix[firstVertex, secondVertex] = 1;
            NumberOfEdges++;
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
   }
}