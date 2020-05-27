using System.Numerics;
using System.Threading.Tasks;

namespace AlgorithmLibrary
{
    public interface IAStarSearchAlgorithm
    {
        Task GetAsync(Vector2 startCoord, Vector2 finishCoord);
    }
}
