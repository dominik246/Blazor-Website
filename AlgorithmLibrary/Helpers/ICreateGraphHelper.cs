using ShortestPathLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Helpers
{
    public interface ICreateGraphHelper
    {
        Task<List<List<IBasicNodeModel>>> GetAsync();
    }
}
