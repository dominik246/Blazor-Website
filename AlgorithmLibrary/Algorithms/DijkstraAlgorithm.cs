using AlgorithmLibrary.Extensions;
using AlgorithmLibrary.Helpers;
using AlgorithmLibrary.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Algorithms
{
    public class DijkstraAlgorithm : IDijkstraAlgorithm
    {
        
        private readonly IGetAllNodesHelper _getNodes;
        private readonly ISortNodesByDistanceHelper _sortNodes;
        private readonly IUpdateUnvisitedNodesHelper _updateGraph;
        private readonly ICreateGraphHelper _createGraph;
        private readonly CreateUnitHelper _unitHelper;
        public DijkstraAlgorithm(IGetAllNodesHelper getNodes, ICreateGraphHelper createGraph, CreateUnitHelper unitHelper,
            ISortNodesByDistanceHelper sortNodes, IUpdateUnvisitedNodesHelper updateGraph)
        {
            _getNodes = getNodes;
            _sortNodes = sortNodes;
            _updateGraph = updateGraph;
            _createGraph = createGraph;
            _unitHelper = unitHelper;
        }

        /// <summary>
        /// Assigns distance values to every node in the given graph.
        /// </summary>
        /// <param name="startCoord"></param>
        /// <param name="finishCoord"></param>
        /// <param name="graph"></param>
        /// <returns>Returns a graph with an assigned distance value to every node.</returns>
        private async Task<List<List<IBasicNodeModel>>> CalculateAsync(List<List<IBasicNodeModel>> graph)
        {
            List<IBasicNodeModel> visitedNodesInOrder = new List<IBasicNodeModel>();

            List<IBasicNodeModel> unvisitedNodes = await _getNodes.GetAsync(graph);

            while (unvisitedNodes.Count > 0)
            {
                unvisitedNodes = await _sortNodes.SortAsync(unvisitedNodes);

                IBasicNodeModel closestNode = unvisitedNodes[0];
                unvisitedNodes.RemoveAt(0);

                if (closestNode.NodeType is UnitType.WallNode)
                    continue;

                if (closestNode.Distance is int.MaxValue)
                    break;

                closestNode.Visited = true;
                visitedNodesInOrder.Add(closestNode);

                if (closestNode.NodeType is UnitType.FinishNode)
                    break;

                await _updateGraph.UpdateAsync(closestNode, graph);
            }

            return graph;
        }

        /// <summary>
        /// Calculates the shortest path.
        /// </summary>
        /// <param name="finishCoord"></param>
        /// <param name="graph"></param>
        /// <returns>Returns the shortest path from the start node to the finish node.</returns>
        private async Task<List<int[]>> ShortestPathAsync(Vector2 finishCoord, List<List<IBasicNodeModel>> graph)
        {
            List<IBasicNodeModel> nodesInShortestPathOrder = new List<IBasicNodeModel>();
            IBasicNodeModel currentNode = graph[(int)finishCoord.Y][(int)finishCoord.X];

            await Task.Run(() =>
            {
                while (!(currentNode is null))
                {
                    nodesInShortestPathOrder.Add(currentNode);

                    if (currentNode.PreviousNodeCoord == new Vector2(-1, -1))
                        break;

                    currentNode = graph[(int)currentNode.PreviousNodeCoord.Y][(int)currentNode.PreviousNodeCoord.X];
                }
            });
            nodesInShortestPathOrder.Reverse();

            List<int[]> result = new List<int[]>();

            foreach(IBasicNodeModel item in nodesInShortestPathOrder)
            {
                result.Add(new int[] { item.CoordX, item.CoordY });
            }

            return result;
        }

        /// <summary>
        /// Gets the shortest path from StartCoord to FinishCoord
        /// </summary>
        /// <param name="startCoord"></param>
        /// <param name="finishCoord"></param>
        /// <returns>Returns the shortest path.</returns>
        private async Task<List<int[]>> GetAsync(JsonElement start, JsonElement finish, JsonElement arr)
        {
            List<List<IBasicNodeModel>> graph = await _createGraph.GetAsync();
            await _unitHelper.FillAsync(graph, start, finish, arr);

            graph = await CalculateAsync(graph);

            return await ShortestPathAsync(finish.ConvertToVector2(), graph);
        }

        public async Task<int[][]> Compute(JsonElement arr)
        {
            if (arr[3].EnumerateArray().Count(item => !string.IsNullOrEmpty(item.GetString())) == 2)
            {
                return (await GetAsync(arr[0][0], arr[1][0], arr)).ToArray();
            }

            List<JsonElement> checkpoints = arr[3].EnumerateArray().ToList();

            List<int[]> result = new List<int[]>();
            for(int i = checkpoints.Count - 1; i >= 0; i--)
            {
                result.AddRange(await GetAsync(checkpoints[i], checkpoints[i - 1], arr));
                checkpoints.RemoveAt(i);

                if (i - 1 == 0) // if we're at Start
                {
                    break;
                }
            }

            return result.ToArray();
        }
    }
}
