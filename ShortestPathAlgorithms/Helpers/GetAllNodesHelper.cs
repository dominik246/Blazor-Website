using ShortestPathAlgorithms.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms.Helpers
{
    public class GetAllNodesHelper
    {
        public async Task<List<BasicNodeModel>> GetAsync(List<List<BasicNodeModel>> graph)
        {
            List<BasicNodeModel> nodes = new List<BasicNodeModel>();

            await Task.Run(() =>
            {
                foreach(var list in graph)
                {
                    foreach(var node in list)
                    {
                        nodes.Add(node);
                    }
                }
            });
            return nodes;
        }
    }
}
