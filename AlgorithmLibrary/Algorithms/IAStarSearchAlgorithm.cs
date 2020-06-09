using System.Numerics;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Algorithms
{
    public interface IAStarSearchAlgorithm
    {
        Task<int[][]> Compute(JsonElement arr);
    }
}
