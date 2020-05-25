using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ShortestPathAlgorithms.Models
{
    public enum UnitType { BasicNode = 0, StartNode, FinishNode, WallNode}

    public class BasicNodeModel
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public bool Visited { get; set; }
        public int Distance { get; set; } = int.MaxValue;
        public UnitType NodeType { get; set; }
        public Vector2 PreviousNodeCoord { get; set; } = new Vector2(-1, -1);
    }
}
