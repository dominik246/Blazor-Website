using AlgorithmLibrary.Models;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Algorithms
{
    public interface IDijkstraAlgorithm
    {
        Task<int[][]> GetAsync(JsonElement arr);
    }
}
