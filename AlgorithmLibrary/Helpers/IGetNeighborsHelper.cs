using ShortestPathLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Helpers
{
    public interface IGetNeighborsHelper
    {
        Task<List<IBasicNodeModel>> GetAsync(IBasicNodeModel node, List<List<IBasicNodeModel>> graph);
    }
}