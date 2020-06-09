using ShortestPathLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Algorithms
{
    public class AlgorithmSelector
    {
        private readonly IDijkstraAlgorithm _dijkstra;
        private readonly IAStarSearchAlgorithm _aStar;
        public AlgorithmSelector(IDijkstraAlgorithm dijkstra, IAStarSearchAlgorithm aStar)
        {
            _dijkstra = dijkstra;
            _aStar = aStar;
        }

        public async Task<int[][]> RunAsync(string algorithm, JsonElement grid)
        {
            int[][] result = default;
            switch (algorithm)
            {
                //case "A* Algorithm":
                //    result = await _aStar.GetAsync(grid);
                //    break;
                //case "Something Something":
                //    break;
                //case "Algorithm Algorithm":
                //    break;
                default: // this is Dijkstra's Algo
                    result = await _dijkstra.Compute(grid);
                    break;
            }
            return result;
        }
    }
}
