using System.Numerics;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Algorithms
{
    public interface IAStarSearchAlgorithm
    {
        Task GetAsync(Vector2 startCoord, Vector2 finishCoord);
    }
}
