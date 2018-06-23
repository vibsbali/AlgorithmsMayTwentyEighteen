using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    public interface IGraphSearch
    {
       bool CanFind(int startingVertex, int goalVertex);
       List<int> TryGetPath(int startingVertex, int goalVertex);
    }
}
