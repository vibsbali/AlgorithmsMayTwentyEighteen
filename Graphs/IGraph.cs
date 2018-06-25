using System.Collections.Generic;
using System.Diagnostics;

namespace Graphs
{
    public interface IGraph
    {
       int NumberOfVertices { get; }
       int GetEdgeWeight(int firstVertex, int secondVertex);
       int NumberOfEdges { get; }
       void AddVertex();
       void AddEdge(int firstVertex, int secondVertex, int weight = 0);
       List<int> GetNeighbours(int vertex);
       bool IsDirected { get; }
    }
}
