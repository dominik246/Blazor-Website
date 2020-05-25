using ShortestPathAlgorithms.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms.Helpers
{
    public class SortNodesByDistanceHelper
    {
        public async Task<List<BasicNodeModel>> Sort(List<BasicNodeModel> unsortedNodes)
        {
            List<BasicNodeModel> sortedNodes = new List<BasicNodeModel>();

            await Task.Run(() => sortedNodes = unsortedNodes.OrderBy(n => n.Distance).ToList());

            return sortedNodes;
        }
    }
}
