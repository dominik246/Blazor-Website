using ShortestPathLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Helpers
{
    public class GetNeighborsHelper : IGetNeighborsHelper
    {
        /// <summary>
        /// Calculates neighbors of a given node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="graph"></param>
        /// <returns>Returns the neighbors of a specified node in the graph.</returns>
        public async Task<List<IBasicNodeModel>> GetAsync(IBasicNodeModel node, List<List<IBasicNodeModel>> graph)
        {
            List<IBasicNodeModel> neighbors = new List<IBasicNodeModel>();
            int col = node.CoordX;
            int row = node.CoordY;

            if (row > 0)
                neighbors.Add(graph[row - 1][col]);
            if (row < graph.Count - 1)
                neighbors.Add(graph[row + 1][col]);
            if (col > 0)
                neighbors.Add(graph[row][col - 1]);
            if (col < graph[0].Count - 1)
                neighbors.Add(graph[row][col + 1]);

            await Task.Run(() => neighbors.RemoveAll(node => node.Visited.Equals(true)));

            return neighbors;
        }
    }
}
