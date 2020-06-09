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
        public async Task<List<double>> SortAsync(JsonElement arr)
        {
            List<double> list = arr.EnumerateArray().ToList().ConvertAll(item => item.GetDouble());
            return await EvaluateAsync(list);
        }

        private async Task<List<double>> EvaluateAsync(List<double> list)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    int jMin = i;
                    for (int j = i + 1; j < list.Count - 1; j++)
                    {
                        if (list[i] > list[j])
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
