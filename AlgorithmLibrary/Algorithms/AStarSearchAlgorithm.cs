using AlgorithmLibrary.Extensions;
using AlgorithmLibrary.Helpers;
using AlgorithmLibrary.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Algorithms
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

        public async Task<int[][]> GetAsync(JsonElement arr)
        {
            List<List<IBasicNodeModel>> graph = await _createGraph.GetAsync();
            await _unitHelper.FillAsync(graph, arr);

            graph = await CalculateAsync(graph);

            return await ShortestPathAsync(arr[0][1].ConvertToVector2(), graph);
        }

        private async Task<List<List<IBasicNodeModel>>> CalculateAsync(List<List<IBasicNodeModel>> graph)
        {
            return null;
        }

        private async Task<int[][]> ShortestPathAsync(Vector2 finishCoord, List<List<IBasicNodeModel>> graph)
        {
            return null;
        }
    }
}
