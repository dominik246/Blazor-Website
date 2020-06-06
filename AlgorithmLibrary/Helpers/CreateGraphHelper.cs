using AlgorithmLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Helpers
{
    public class CreateGraphHelper : ICreateGraphHelper
    {
        /// <summary>
        /// Creates a 2D list based on the given parameters.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>Returns a 2D list.</returns>
        public async Task<List<List<IBasicNodeModel>>> GetAsync()
        {
            List<List<IBasicNodeModel>> graph = new List<List<IBasicNodeModel>>();

            const int width = 25;
            const int height = 48;

            await Task.Run(() =>
            {
                for (int i = 0; i < height; i++)
                {
                    graph.Add(new List<IBasicNodeModel>());
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
