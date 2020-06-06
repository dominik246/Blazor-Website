using AlgorithmLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Helpers
{
    public interface ICreateGraphHelper
    {
        Task<List<List<IBasicNodeModel>>> GetAsync();
    }
}
