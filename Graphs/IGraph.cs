using System.Collections.Generic;
using System.Diagnostics;

namespace Graphs
{
    public interface IGraph
    {
       int NumberOfVertices { get; }
       int NumberOfEdges { get; }
       void AddVertex();
       void AddEdge(int firstVertex, int secondVertex);
       List<int> GetNeighbours(int vertex);
    }
}
