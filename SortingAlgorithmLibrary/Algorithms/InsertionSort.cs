using SortingAlgorithmLibrary.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SortingAlgorithmLibrary.Algorithms
{
    public class InsertionSort
    {
        public async Task<List<object[]>> SortAsync(JsonElement arr)
        {
            List<JsonElement> list = arr.EnumerateArray().ToList();
            // arr.push() has to be [index, text, height, sortName]
            List<(int, string, double, string)> heights = list.ConvertAll(item => item.ConvertToTuple());
            return await EvaluateAsync(heights);
        }

        private async Task<List<object[]>> EvaluateAsync(List<(int, string, double, string)> list)
        {
            List<object[]> instructions = new List<object[]>();
            await Task.Run(() =>
            {
                for (int i = 1; i < list.Count; i++)
                {
                    int j = i;
                    while (j > 0 && list[j - 1].Item3 > list[j].Item3)
                    {
                        instructions.Add(new object[] { list[j].Item1, list[j - 1].Item1, true });
                        (list[j], list[j - 1]) = (list[j - 1], list[j]);
                        j--;
                    }
                    instructions.Add(new object[] { list[j].Item1, list[j].Item1, true });
                }
            });
            return instructions;
        }


    }
}
