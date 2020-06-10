using SortingAlgorithmLibrary.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SortingAlgorithmLibrary.Algorithms
{
    public class SelectSortingAlgorithm
    {
        private readonly SelectionSort _selection;
        private readonly InsertionSort _insertion;
        private readonly HeapSort _heap;
        public SelectSortingAlgorithm(SelectionSort selection, InsertionSort insertion, HeapSort heap)
        {
            _selection = selection;
            _insertion = insertion;
            _heap = heap;
        }

        public async Task<object[][]> Select(JsonElement arr, string algo)
        {
            object[][] result;

            List<JsonElement> list = arr.EnumerateArray().ToList();
            // arr.push() has to be [index, text, height, sortName]
            List<(int, string, double, string)> heights = list.ConvertAll(item => item.ConvertToTuple());

            switch (algo)
            {
                case "Insertion Sort":
                    result = (await _insertion.SortAsync(heights)).ToArray();
                    break;
                case "Heap Sort":
                    result = (await _heap.SortAsync(heights)).ToArray();
                    break;
                default:
                    result = (await _selection.SortAsync(heights)).ToArray();
                    break;
            }
            return result;
        }
    }
}
