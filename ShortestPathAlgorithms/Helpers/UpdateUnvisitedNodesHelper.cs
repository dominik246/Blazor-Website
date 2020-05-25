using ShortestPathAlgorithms.Models;

using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms.Helpers
{
    public class UpdateUnvisitedNodesHelper
    {
        private readonly GetNeighborsHelper _neighbors;

        public UpdateUnvisitedNodesHelper(GetNeighborsHelper neighbors)
        {
            _neighbors = neighbors;
        }

        /// <summary>
        /// Updates all the neighbors of a specified node and their values.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="graph"></param>
        public async Task UpdateAsync(BasicNodeModel node, List<List<BasicNodeModel>> graph)
        {
            List<BasicNodeModel> list = await _neighbors.GetAsync(node, graph);

            foreach (var neighbor in list)
            {
                var neighborInGraph = graph[neighbor.CoordY][neighbor.CoordX];
                neighborInGraph.Distance = node.Distance + 1;
                neighborInGraph.PreviousNodeCoord = new Vector2(node.CoordX, node.CoordY);
            }
        }
    }
}
