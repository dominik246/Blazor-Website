using ShortestPathLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Helpers
{
    public interface ISortNodesByDistanceHelper
    {
        Task<List<IBasicNodeModel>> SortAsync(List<IBasicNodeModel> unsortedNodes);
    }
}