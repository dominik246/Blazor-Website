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
        public SelectSortingAlgorithm(SelectionSort selection)
        {
            _selection = selection;
        }

        public async Task<object[][]> Select(JsonElement arr, string algo)
        {
            object[][] result;
            switch (algo)
            {
                case "":
                default:
                    result = (await _selection.SortAsync(arr)).ConvertAll(item => item.ConvertToArray()).ToArray();
                    break;
            }
            return result;
        }
    }
}
