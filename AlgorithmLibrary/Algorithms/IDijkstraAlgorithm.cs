using ShortestPathLibrary.Models;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Algorithms
{
    public interface IDijkstraAlgorithm
    {
        Task<int[][]> Compute(JsonElement arr);
    }
}
