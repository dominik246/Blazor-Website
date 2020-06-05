using AlgorithmLibrary.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Extensions
{
    public class CreateUnitHelper
    {
        public async Task FillAsync(List<List<IBasicNodeModel>> graph, JsonElement arr)
        {
            List<List<IBasicNodeModel>> list = new List<List<IBasicNodeModel>>();

            list.Add(new List<IBasicNodeModel>());
            Vector2 startCoord = arr[0][0].ConvertToVector2();
            list[0].Add(CreateUnit(coord: startCoord, distance: 0, type: UnitType.StartNode, previousNodeCoord: new Vector2(-1, -1)));

            Vector2 finishNode = arr[0][1].ConvertToVector2();
            list[0].Add(CreateUnit(coord: finishNode, type: UnitType.FinishNode));

            list.Add(new List<IBasicNodeModel>());
            await Task.Run(() =>
            {
                foreach (JsonElement coords in arr[1].EnumerateArray())
                {
                    list[1].Add(CreateUnit(coord: coords.ConvertToVector2(), visited: true, type: UnitType.WallNode));
                }
            });

            await graph.DefineAsync(list);
        }

        public IBasicNodeModel CreateUnit(Vector2 coord = default, bool visited = false, int distance = int.MaxValue,
            UnitType type = UnitType.BasicNode, Vector2 previousNodeCoord = default)
        {
            return new BasicNodeModel
            {
                CoordX = (int)coord.X,
                CoordY = (int)coord.Y,
                Visited = visited,
                Distance = distance,
                NodeType = type,
                PreviousNodeCoord = previousNodeCoord
            };
        }
    }
}
