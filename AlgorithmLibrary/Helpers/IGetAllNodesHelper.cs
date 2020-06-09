using ShortestPathLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Helpers
{
    public interface IGetAllNodesHelper
    {
        Task<List<IBasicNodeModel>> GetAsync(List<List<IBasicNodeModel>> graph);
    }
}