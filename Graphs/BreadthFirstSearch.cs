﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
   public class BreadthFirstSearch : IGraphSearch
   {
      public BreadthFirstSearch(IGraph graphToSearch)
      {
         GraphToSearch = graphToSearch;
      }

      public IGraph GraphToSearch { get; private set; }

      public bool CanFind(int startingVertex, int goalVertex)
      {
         if (startingVertex > GraphToSearch.NumberOfVertices || goalVertex > GraphToSearch.NumberOfVertices)
         {
            throw new InvalidOperationException();
         }

         VertexToSearch = startingVertex;
         Goal = goalVertex;

         //stack of vertex to search next
         var queue = new Queue<int>();

         //list of visited
         var dictionaryOfVisited = new Dictionary<int, int>();

         queue.Enqueue(startingVertex);
         while (queue.Count > 0)
         {
            var currentVertex = queue.Dequeue();

            //Have we reached the goal
            if (currentVertex == goalVertex)
            {
               return true;
            }

            //Have we seen this node before, if so unwind the stack as we do not want to explore this node again
            if (dictionaryOfVisited.ContainsKey(currentVertex))
            {
               continue;
            }

            //Otherwise add to visited
            dictionaryOfVisited.Add(currentVertex, currentVertex);
            //search for neighbours
            var listOfNeighbours = GraphToSearch.GetNeighbours(currentVertex);
            foreach (var neighbour in listOfNeighbours.Where(n => !dictionaryOfVisited.ContainsKey(n)))
            {
               queue.Enqueue(neighbour);
            }
         }

         return false;
      }

      public int Goal { get; private set; }

      public int VertexToSearch { get; private set; }
   }
}