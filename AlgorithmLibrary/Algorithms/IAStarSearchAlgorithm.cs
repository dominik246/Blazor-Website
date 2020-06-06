using System.Numerics;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Algorithms
{
    public interface IAStarSearchAlgorithm
    {
        Task<int[][]> GetAsync(JsonElement arr);
    }
}
