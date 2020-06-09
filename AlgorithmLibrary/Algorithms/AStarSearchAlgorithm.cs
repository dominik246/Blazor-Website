using ShortestPathLibrary.Extensions;
using ShortestPathLibrary.Helpers;
using ShortestPathLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Algorithms
{
    public class AStarSearchAlgorithm : IAStarSearchAlgorithm
    {
        private readonly ICreateGraphHelper _createGraph;
        private readonly CreateUnitHelper _unitHelper;
        public AStarSearchAlgorithm(ICreateGraphHelper createGraph, CreateUnitHelper unitHelper)
        {
            _createGraph = createGraph;
            _unitHelper = unitHelper;
        }

        public async Task<int[][]> Compute(JsonElement arr)
        {
            if (arr[3].GetArrayLength() == 0)
            {
                return (await GetAsync(arr[0][0], arr[1][0], arr)).ToArray();
            }

            List<JsonElement> checkpoints = arr[3].EnumerateArray().ToList();

            List<int[]> result = new List<int[]>();
            foreach (JsonElement item in checkpoints)
            {
                result.AddRange(await GetAsync(checkpoints[0], checkpoints[1], arr));
            }

            return result.ToArray();
        }

        private async Task<List<int[]>> GetAsync(JsonElement start, JsonElement finish, JsonElement arr)
        {
            List<List<IBasicNodeModel>> graph = await _createGraph.GetAsync();
            await _unitHelper.FillAsync(graph, start, finish, arr);

            graph = await CalculateAsync(graph);

            return await ShortestPathAsync(finish.ConvertToVector2(), graph);
        }

        private async Task<List<List<IBasicNodeModel>>> CalculateAsync(List<List<IBasicNodeModel>> graph)
        {
            return null;
        }

        private async Task<List<int[]>> ShortestPathAsync(Vector2 finishCoord, List<List<IBasicNodeModel>> graph)
        {
            return null;
        }
    }
}
