using AlgorithmLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Helpers
{
    public interface IGetAllNodesHelper
    {
        Task<List<IBasicNodeModel>> GetAsync(List<List<IBasicNodeModel>> graph);
    }
}