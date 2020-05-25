using ShortestPathAlgorithms.Extensions;
using ShortestPathAlgorithms.Helpers;
using ShortestPathAlgorithms.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms.Algorithms
{
    public class DijkstraAlgorithm
    {
        private readonly CreateGraphHelper _createGraph;
        private readonly GetAllNodesHelper _getNodes;
        private readonly SortNodesByDistanceHelper _sortNodes;
        private readonly UpdateUnvisitedNodesHelper _updateGraph;

        public DijkstraAlgorithm(CreateGraphHelper createGraph, GetAllNodesHelper getNodes, SortNodesByDistanceHelper sortNodes, UpdateUnvisitedNodesHelper updateGraph)
        {
            _createGraph = createGraph;
            _getNodes = getNodes;
            _sortNodes = sortNodes;
            _updateGraph = updateGraph;
        }

        private async Task<List<List<BasicNodeModel>>> Calculate(Vector2 startCoord, Vector2 finishCoord, List<List<BasicNodeModel>> graph)
        {
            //TODO: bind with website so that it's dynamic
            // starts with 0
            const int width = 3;
            const int height = 3;
            
            graph = await _createGraph.GetAsync(width, height);

            List<BasicNodeModel> visitedNodesInOrder = new List<BasicNodeModel>();

            BasicNodeModel startNode = new BasicNodeModel
            {
                Distance = 0,
                CoordX = (int)startCoord.X,
                CoordY = (int)startCoord.Y,
                NodeType = UnitType.StartNode
            };

            BasicNodeModel finishNode = new BasicNodeModel
            {
                CoordX = (int)finishCoord.X,
                CoordY = (int)finishCoord.Y,
                NodeType = UnitType.FinishNode
            };

            graph.Define(new BasicNodeModel[] { startNode, finishNode });

            List<BasicNodeModel> unvisitedNodes = await _getNodes.GetAsync(graph);

            while (unvisitedNodes.Count > 0)
            {
                unvisitedNodes = await _sortNodes.Sort(unvisitedNodes);

                //foreach (var node in unvisitedNodes)
                //{
                //    if (node.NodeType is UnitType.StartNode ||
                //        node.NodeType is UnitType.FinishNode)
                //    {
                //        Console.WriteLine("helo");
                //    }
                //}

                BasicNodeModel closestNode = unvisitedNodes[0];
                unvisitedNodes.RemoveAt(0);

                if (closestNode.NodeType is UnitType.WallNode)
                    continue;

                if (closestNode.Distance is int.MaxValue)
                    break;

                closestNode.Visited = true;
                visitedNodesInOrder.Add(closestNode);

                if (closestNode.NodeType is UnitType.FinishNode)
                    break;

                await _updateGraph.Update(closestNode, graph);
            }

            return graph;
        }

        private async Task<List<BasicNodeModel>> ShortestPath(Vector2 finishCoord, List<List<BasicNodeModel>> graph)
        {
            List<BasicNodeModel> nodesInShortestPathOrder = new List<BasicNodeModel>();
            var currentNode = graph[(int)finishCoord.Y][(int)finishCoord.X];

            await Task.Run(() =>
            {
                // forever loop
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

        public async Task Get(Vector2 startCoord, Vector2 finishCoord)
        {
            List<List<BasicNodeModel>> graph = new List<List<BasicNodeModel>>();

            graph = await Calculate(startCoord, finishCoord, graph);

            //foreach (var list in graph)
            //{
            //    foreach (var unit in list)
            //    {
            //        var distance = unit.Distance;

            //        if (distance is int.MaxValue)
            //            distance = -1;

            //        Console.Write($"{distance}, ");
            //    }
            //    Console.Write(Environment.NewLine);
            //}

            var shortestPathList = await ShortestPath(finishCoord, graph);

            foreach(var node in shortestPathList)
            {
                Console.WriteLine($"{node.CoordX}, {node.CoordY}");
            }
        }
    }
}
