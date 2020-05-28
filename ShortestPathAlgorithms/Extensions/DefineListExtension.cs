using AlgorithmLibrary.Models;

using System.Collections.Generic;

namespace ShortestPathAlgorithms.Extensions
{
    public static class DefineListExtension
    {
        /// <summary>
        /// Replaces a basic node with the specified node in the graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="node"></param>
        public static void Define(this List<List<IBasicNodeModel>> graph, IBasicNodeModel node)
        {
            graph[node.CoordY][node.CoordX] = node;
        }

        /// <summary>
        /// Replaces the basic nodes with the specified nodes in the graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="nodes"></param>
        public static void Define(this List<List<IBasicNodeModel>> graph, IBasicNodeModel[] nodes)
        {
            foreach (var node in nodes)
            {
                graph[node.CoordY][node.CoordX] = node;
            }
        }
    }
}
