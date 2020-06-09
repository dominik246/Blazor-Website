using ShortestPathLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Helpers
{
    public interface IUpdateUnvisitedNodesHelper
    {
        Task UpdateAsync(IBasicNodeModel node, List<List<IBasicNodeModel>> graph);
    }
}