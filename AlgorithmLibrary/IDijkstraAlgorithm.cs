using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibrary
{
    public interface IDijkstraAlgorithm
    {
        Task GetAsync(Vector2 startCoord, Vector2 finishCoord);
    }
}
