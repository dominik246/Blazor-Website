using System.Numerics;

namespace ShortestPathLibrary.Models
{
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
