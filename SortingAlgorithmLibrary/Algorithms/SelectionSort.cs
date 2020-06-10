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
        public async Task<List<object[]>> SortAsync(List<(int, string, double, string)> list)
        {
            List<object[]> instructions = new List<object[]>();

            await Task.Run(() =>
            {
                string temp = list[0].Item4;
                for (int i = 0; i < list.Count; i++)
                {
                    int jMin = i;
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[jMin].Item3 > list[j].Item3)
                        {
                            jMin = j;
                        }
                        instructions.Add(new object[] { list[jMin].Item1, list[j].Item1, false });
                    }
                    if (jMin != i)
                    {
                        (list[i], list[jMin]) = (list[jMin], list[i]);
                        instructions.Add(new object[] { list[jMin].Item1, list[i].Item1, true });
                    }
                    else
                    {
                        instructions.Add(new object[] { list[i].Item1, list[i].Item1, true });
                    }
                }
            });
            return instructions;
        }
    }
}
