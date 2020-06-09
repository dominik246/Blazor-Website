using System.Numerics;

namespace ShortestPathLibrary.Models
{
    public enum UnitType { BasicNode, StartNode, FinishNode, WallNode, CheckPoint }

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
