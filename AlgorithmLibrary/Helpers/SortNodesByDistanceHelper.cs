using ShortestPathLibrary.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Helpers
{
    public class SortNodesByDistanceHelper : ISortNodesByDistanceHelper
    {
        /// <summary>
        /// Sorts a given list based on the Distance property.
        /// </summary>
        /// <param name="unsortedNodes"></param>
        /// <returns>Returns a list that has been sorted based on the Distance property.</returns>
        public async Task<List<IBasicNodeModel>> SortAsync(List<IBasicNodeModel> unsortedNodes)
        {
            List<IBasicNodeModel> sortedNodes = new List<IBasicNodeModel>();

            await Task.Run(() => sortedNodes = unsortedNodes.OrderByDescending(n => n.Distance).ToList());

            return sortedNodes;
        }
    }
}
