using SortingAlgorithmLibrary.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SortingAlgorithmLibrary.Algorithms
{
    public class SelectionSort
    {
        public async Task<List<(int, double, string)>> SortAsync(JsonElement arr)
        {
            List<JsonElement> list = arr.EnumerateArray().ToList();
            List<(int, double, string)> heights = list.ConvertAll(item => item.ConvertToTuple());
            return await EvaluateAsync(heights);
        }

        private async Task<List<(int, double, string)>> EvaluateAsync(List<(int, double, string)> list)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < list.Count; i++)
                {
                    int jMin = i;
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[jMin].Item2 > list[j].Item2)
                        {
                            jMin = j;
                        }
                    }
                    if (jMin != i)
                    {
                        (list[i], list[jMin]) = (list[jMin], list[i]);
                    }
                }
            });
            return list;
        }
    }
}
