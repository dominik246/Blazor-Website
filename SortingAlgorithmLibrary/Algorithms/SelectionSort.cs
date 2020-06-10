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
        public async Task<List<(int, string, double, double[], string)>> SortAsync(JsonElement arr)
        {
            List<JsonElement> list = arr.EnumerateArray().ToList();
            // arr.push() has to be [index, text, height, [h, s, v], sortName]
            List<(int, string, double, double[], string)> heights = list.ConvertAll(item => item.ConvertToTuple());
            return await EvaluateAsync(heights);
        }

        private async Task<List<(int, string, double, double[], string)>> EvaluateAsync(List<(int, string, double, double[], string)> list)
        {
            await Task.Run(() =>
            {
                string temp = list[0].Item5;

                for (int i = 0; i < list.Count; i++)
                {
                    int jMin = i;
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        switch (temp)
                        {
                            case "By Height":
                                if (list[jMin].Item3 > list[j].Item3)
                                {
                                    jMin = j;
                                }
                                break;
                            case "By HSV Hue":
                                if (list[jMin].Item4[0] > list[j].Item4[0])
                                {
                                    jMin = j;
                                }
                                break;
                            case "By HSV Saturation":
                                if (list[jMin].Item4[1] > list[j].Item4[1])
                                {
                                    jMin = j;
                                }
                                break;
                            case "By HSV value":
                                if (list[jMin].Item4[2] > list[j].Item4[2])
                                {
                                    jMin = j;
                                }
                                break;
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
