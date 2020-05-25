using ShortestPathAlgorithms.Models;

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms.Helpers
{
    public class UpdateUnvisitedNodesHelper
    {
        private GetNeighborsHelper _neighbors;

        public UpdateUnvisitedNodesHelper(GetNeighborsHelper neighbors)
        {
            _neighbors = neighbors;
        }

        public async Task Update(BasicNodeModel node, List<List<BasicNodeModel>> graph)
        {
            List<BasicNodeModel> list = await _neighbors.Get(node, graph);

            foreach(var neighbor in list)
            {
                var neighborInGraph = graph[neighbor.CoordY][neighbor.CoordX];
                neighborInGraph.Distance = node.Distance + 1;
                neighborInGraph.PreviousNodeCoord = new Vector2(node.CoordX, node.CoordY);
            }
        }
    }
}
