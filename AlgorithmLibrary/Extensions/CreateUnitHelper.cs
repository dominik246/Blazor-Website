using AlgorithmLibrary.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Extensions
{
    public class CreateUnitHelper
    {
        public IBasicNodeModel Create(Vector2 coord = default, bool visited = false, int distance = int.MaxValue, 
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
