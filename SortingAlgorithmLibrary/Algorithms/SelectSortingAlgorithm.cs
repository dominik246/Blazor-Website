using SortingAlgorithmLibrary.Extensions;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SortingAlgorithmLibrary.Algorithms
{
    public class SelectSortingAlgorithm
    {
        private readonly SelectionSort _selection;
        private readonly InsertionSort _insertion;
        public SelectSortingAlgorithm(SelectionSort selection, InsertionSort insertion)
        {
            _selection = selection;
            _insertion = insertion;
        }

        public async Task<object[][]> Select(JsonElement arr, string algo)
        {
            object[][] result;
            switch (algo)
            {
                case "Insertion Sort":
                    result = (await _insertion.SortAsync(arr)).ToArray();
                    break;
                default:
                    result = (await _selection.SortAsync(arr)).ToArray();
                    break;
            }
            return result;
        }
    }
}
