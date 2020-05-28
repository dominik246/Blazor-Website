using AlgorithmLibrary.Extensions;
using AlgorithmLibrary.Helpers;
using AlgorithmLibrary.Models;

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Algorithms
{
    public class DijkstraAlgorithm : IDijkstraAlgorithm
    {
        private readonly ICreateGraphHelper _createGraph;
        private readonly IGetAllNodesHelper _getNodes;
        private readonly ISortNodesByDistanceHelper _sortNodes;
        private readonly IUpdateUnvisitedNodesHelper _updateGraph;

        public DijkstraAlgorithm(ICreateGraphHelper createGraph, IGetAllNodesHelper getNodes, ISortNodesByDistanceHelper sortNodes, IUpdateUnvisitedNodesHelper updateGraph)
        {
            _createGraph = createGraph;
            _getNodes = getNodes;
            _sortNodes = sortNodes;
            _updateGraph = updateGraph;
        }

        /// <summary>
        /// Assigns distance values to every node in the given graph.
        /// </summary>
        /// <param name="startCoord"></param>
        /// <param name="finishCoord"></param>
        /// <param name="graph"></param>
        /// <returns>Returns a graph with an assigned distance value to every node.</returns>
        private async Task<List<List<IBasicNodeModel>>> CalculateAsync(Vector2 startCoord, Vector2 finishCoord, List<List<IBasicNodeModel>> graph)
        {
            //TODO: bind with website so that it's dynamic
            // starts with 0
            const int width = 3;
            const int height = 3;

            graph = await _createGraph.GetAsync(width, height);

            List<IBasicNodeModel> visitedNodesInOrder = new List<IBasicNodeModel>();

            IBasicNodeModel startNode = new BasicNodeModel
            {
                Distance = 0,
                CoordX = (int)startCoord.X,
                CoordY = (int)startCoord.Y,
                NodeType = UnitType.StartNode
            };

            IBasicNodeModel finishNode = new BasicNodeModel
            {
                CoordX = (int)finishCoord.X,
                CoordY = (int)finishCoord.Y,
                NodeType = UnitType.FinishNode
            };

            graph.Define(new IBasicNodeModel[] { startNode, finishNode });

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
        private async Task<List<IBasicNodeModel>> ShortestPathAsync(Vector2 finishCoord, List<List<IBasicNodeModel>> graph)
        {
            List<IBasicNodeModel> nodesInShortestPathOrder = new List<IBasicNodeModel>();
            var currentNode = graph[(int)finishCoord.Y][(int)finishCoord.X];

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
            return nodesInShortestPathOrder;
        }

        /// <summary>
        /// Gets the shortest path from StartCoord to FinishCoord
        /// </summary>
        /// <param name="startCoord"></param>
        /// <param name="finishCoord"></param>
        /// <returns>Returns the shortest path.</returns>
        public async Task GetAsync(Vector2 startCoord, Vector2 finishCoord)
        {
            List<List<IBasicNodeModel>> graph = new List<List<IBasicNodeModel>>();

            graph = await CalculateAsync(startCoord, finishCoord, graph);

            var shortestPathList = await ShortestPathAsync(finishCoord, graph);

            foreach (var node in shortestPathList)
            {
                Console.WriteLine($"{node.CoordX}, {node.CoordY}");
            }
        }
    }
}
