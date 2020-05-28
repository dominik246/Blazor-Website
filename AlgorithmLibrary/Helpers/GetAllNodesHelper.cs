using AlgorithmLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Helpers
{
    public class GetAllNodesHelper : IGetAllNodesHelper
    {
        /// <summary>
        /// Converts a given 2D list to a 1D list.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>Returns a 1D list.</returns>
        public async Task<List<IBasicNodeModel>> GetAsync(List<List<IBasicNodeModel>> graph)
        {
            List<IBasicNodeModel> nodes = new List<IBasicNodeModel>();

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
