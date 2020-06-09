using ShortestPathLibrary.Models;

using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Helpers
{
    public class UpdateUnvisitedNodesHelper : IUpdateUnvisitedNodesHelper
    {
        private readonly IGetNeighborsHelper _neighbors;

        public UpdateUnvisitedNodesHelper(IGetNeighborsHelper neighbors)
        {
            _neighbors = neighbors;
        }

        /// <summary>
        /// Updates all the neighbors of a specified node and their values.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="graph"></param>
        public async Task UpdateAsync(IBasicNodeModel node, List<List<IBasicNodeModel>> graph)
        {
            List<IBasicNodeModel> list = await _neighbors.GetAsync(node, graph);

            foreach (var neighbor in list)
            {
                var neighborInGraph = graph[neighbor.CoordY][neighbor.CoordX];
                neighborInGraph.Distance = node.Distance + 1;
                neighborInGraph.PreviousNodeCoord = new Vector2(node.CoordX, node.CoordY);
            }
        }
    }
}
