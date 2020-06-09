using ShortestPathLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Extensions
{
    public static class DefineListExtension
    {
        /// <summary>
        /// Replaces a basic node with the specified node in the graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="node"></param>
        public static async Task DefineAsync(this List<List<IBasicNodeModel>> graph, List<List<IBasicNodeModel>> nodeList)
        {
            await Task.Run(async() =>
            {
                foreach(List<IBasicNodeModel> subList in nodeList)
                {
                    await graph.DefineAsync(subList);
                }
            });
        }

        /// <summary>
        /// Replaces the basic nodes with the specified nodes in the graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="nodes"></param>
        public static async Task DefineAsync(this List<List<IBasicNodeModel>> graph, List<IBasicNodeModel> nodes)
        {
            await Task.Run(() =>
            {
                foreach (var node in nodes)
                {
                    graph[node.CoordY][node.CoordX] = node;
                }
            });
        }
    }
}
