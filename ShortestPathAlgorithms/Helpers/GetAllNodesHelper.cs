using ShortestPathAlgorithms.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms.Helpers
{
    public class GetAllNodesHelper
    {
        /// <summary>
        /// Converts a given 2D list to a 1D list.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>Returns a 1D list.</returns>
        public async Task<List<BasicNodeModel>> GetAsync(List<List<BasicNodeModel>> graph)
        {
            List<BasicNodeModel> nodes = new List<BasicNodeModel>();

            await Task.Run(() =>
            {
                foreach (var list in graph)
                {
                    foreach (var node in list)
                    {
                        nodes.Add(node);
                    }
                }
            });
            return nodes;
        }
    }
}
