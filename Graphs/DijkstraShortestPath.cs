using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
   public class DijkstraShortestPath : IGraphSearch
   {
      public DijkstraShortestPath(IGraph graphToSearch)
      {
         GraphToSearch = graphToSearch;
      }

      public IGraph GraphToSearch { get; }
      public int Goal { get; private set; }
      public Dictionary<int, int> ParentMap { get; set; } = new Dictionary<int, int>();

      public int StartingVertex { get; private set; }

      public bool CanFind(int startingVertex, int goalVertex)
      {
         if (startingVertex > GraphToSearch.NumberOfVertices || goalVertex > GraphToSearch.NumberOfVertices)
         {
            throw new InvalidOperationException();
         }

         StartingVertex = startingVertex;
         Goal = goalVertex;

         //ideally this should be a priority queue
         var priorityQueue = new List<Tuple<int, int>>();
         
         //list of visited
         var dictionaryOfVisited = new Dictionary<int, int>();

         var cummulativeDistance = 0;
         //Initially start with 0 weight - sorted dictionary sorts the values based on keys
         priorityQueue.Add(new Tuple<int, int>(startingVertex, cummulativeDistance));
         
         while (priorityQueue.Count != 0)
         {
            var node = priorityQueue.OrderBy(n => n.Item2).First();
            priorityQueue.Remove(node);

            if (node.Item1 == goalVertex)
            {
               return true;
            }

            //Have we seen this node before, if so unwind the stack as we do not want to explore this node again
            if (dictionaryOfVisited.ContainsKey(node.Item1))
            {
               continue;
            }

            //Otherwise update distance and add to visited
            cummulativeDistance = cummulativeDistance + node.Item2;            
            dictionaryOfVisited.Add(node.Item1, node.Item1);
            //search for neighbours
            var listOfNeighbours = GraphToSearch.GetNeighbours(node.Item1);
            foreach (var neighbour in listOfNeighbours.Where(n => !dictionaryOfVisited.ContainsKey(n)))
            {
               priorityQueue.Add(new Tuple<int, int>(neighbour, GraphToSearch.GetEdgeWeight(node.Item1, neighbour) + cummulativeDistance));
               ParentMap.AddOrUpdate(neighbour, node.Item1);
            }
         }

         return false;
      }

      public List<int> PathToGoal()
      {
         var stack = new Stack<int>();
         stack.Push(Goal);
         while (stack.Peek() != StartingVertex)
         {
            var current = ParentMap[stack.Peek()];
            stack.Push(current);
         }

         return stack.ToList();
      }
   }
}
