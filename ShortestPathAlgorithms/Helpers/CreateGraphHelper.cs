using AlgorithmLibrary.IModels;

using ShortestPathAlgorithms.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms.Helpers
{
    public class CreateGraphHelper
    {
        /// <summary>
        /// Creates a 2D list based on the given parameters.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>Returns a 2D list.</returns>
        public async Task<List<List<BasicNodeModel>>> GetAsync(int width, int height)
        {
            List<List<BasicNodeModel>> graph = new List<List<BasicNodeModel>>();

            await Task.Run(() =>
            {
                for (int i = 0; i < height; i++)
                {
                    graph.Add(new List<BasicNodeModel>());
                    for (int j = 0; j < width; j++)
                    {
                        graph[i].Add(new BasicNodeModel
                        {
                            CoordX = j,
                            CoordY = i,
                            Visited = false,
                            Distance = int.MaxValue,
                            NodeType = UnitType.BasicNode
                        });
                    }
                }
            });

            return graph;
        }
    }
}
