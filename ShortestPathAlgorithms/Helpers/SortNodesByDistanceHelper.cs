using ShortestPathAlgorithms.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms.Helpers
{
    public class SortNodesByDistanceHelper
    {
        /// <summary>
        /// Sorts a given list based on the Distance property.
        /// </summary>
        /// <param name="unsortedNodes"></param>
        /// <returns>Returns a list that has been sorted based on the Distance property.</returns>
        public async Task<List<BasicNodeModel>> SortAsync(List<BasicNodeModel> unsortedNodes)
        {
            List<BasicNodeModel> sortedNodes = new List<BasicNodeModel>();

            await Task.Run(() => sortedNodes = unsortedNodes.OrderBy(n => n.Distance).ToList());

            return sortedNodes;
        }
    }
}
