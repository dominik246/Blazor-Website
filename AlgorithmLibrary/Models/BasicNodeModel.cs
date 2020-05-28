using System.Numerics;

namespace AlgorithmLibrary.Models
{
    /// <summary>
    /// Enum containing all the possible unit types that can occur in the graph.
    /// </summary>
    //public enum UnitType { BasicNode = 0, StartNode, FinishNode, WallNode, CheckPoint }

    /// <summary>
    /// Constructor for the basic node in the graph.
    /// </summary>
    public class BasicNodeModel : IBasicNodeModel
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public bool Visited { get; set; }
        public int Distance { get; set; } = int.MaxValue;
        public UnitType NodeType { get; set; }
        public Vector2 PreviousNodeCoord { get; set; } = new Vector2(-1, -1);
    }
}
