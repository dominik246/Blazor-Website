using AlgorithmLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Helpers
{
    public interface IGetNeighborsHelper
    {
        Task<List<IBasicNodeModel>> GetAsync(IBasicNodeModel node, List<List<IBasicNodeModel>> graph);
    }
}