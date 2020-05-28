using AlgorithmLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Helpers
{
    public interface ISortNodesByDistanceHelper
    {
        Task<List<IBasicNodeModel>> SortAsync(List<IBasicNodeModel> unsortedNodes);
    }
}