using ShortestPathAlgorithms.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace ShortestPathAlgorithms.Extensions
{
    public static class DefineListExtension
    {
        public static void Define(this List<List<BasicNodeModel>> graph, BasicNodeModel node)
        {
            graph[node.CoordY][node.CoordX] = node;
        }

        public static void Define(this List<List<BasicNodeModel>> graph, BasicNodeModel[] nodes)
        {
            foreach(var node in nodes)
            {
                graph[node.CoordY][node.CoordX] = node;
            }
        }
    }
}
