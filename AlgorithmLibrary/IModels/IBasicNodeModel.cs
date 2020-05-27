using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AlgorithmLibrary.IModels
{
    public enum UnitType { BasicNode = 0, StartNode, FinishNode, WallNode, CheckPoint }

    public interface IBasicNodeModel
    {
        int CoordX { get; set; }
        int CoordY { get; set; }
        int Distance { get; set; }
        UnitType NodeType { get; set; }
        Vector2 PreviousNodeCoord { get; set; }
        bool Visited { get; set; }
    }
}
