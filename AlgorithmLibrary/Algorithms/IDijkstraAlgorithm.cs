using System.Numerics;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Algorithms
{
    public interface IDijkstraAlgorithm
    {
        Task GetAsync(Vector2 startCoord, Vector2 finishCoord);
    }
}
