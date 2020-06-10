using SortingAlgorithmLibrary.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SortingAlgorithmLibrary.Algorithms
{
    public class HeapSort
    {
        private List<object[]> Instructions { get; set; }
        private List<(int, string, double, string)> ArrList { get; set; }
        public async Task<List<object[]>> SortAsync(List<(int, string, double, string)> list)
        {
            Instructions = new List<object[]>();
            ArrList = list;

            await Heapify();

            int end = ArrList.Count - 1;
            while (end > 0)
            {
                Instructions.Add(new object[] { ArrList[end].Item1, ArrList[0].Item1, true });
                (ArrList[end], ArrList[0]) = (ArrList[0], ArrList[end]);
                end--;
                await SiftDown(0, end);
            }
            Instructions.Add(new object[] { ArrList[end].Item1, ArrList[end].Item1, true });
            return Instructions;
        }

        private async Task Heapify()
        {
            int start = IParent(ArrList.Count - 1);

            await Task.Run(async() =>
            {
                while (start >= 0)
                {
                    await SiftDown(start, ArrList.Count - 1);
                    start--;
                }
            });
        }

        private async Task SiftDown(int start, int end)
        {
            int root = start;
            await Task.Run(() =>
            {
                while (ILeftChild(root) <= end)
                {
                    int child = ILeftChild(root);
                    int swap = root;

                    if (ArrList[swap].Item3 < ArrList[child].Item3)
                    {
                        swap = child;
                    }
                    if (child + 1 <= end && ArrList[swap].Item3 < ArrList[child + 1].Item3)
                    {
                        swap = child + 1;
                    }
                    if (swap == root)
                    {
                        break;
                    }
                    else
                    {
                        Instructions.Add(new object[] { ArrList[root].Item1, ArrList[swap].Item1, true});
                        (ArrList[root], ArrList[swap]) = (ArrList[swap], ArrList[root]);
                        root = swap;
                    }
                }
            });
        }

        private int IParent(int num)
        {
            return (int)Math.Floor(double.Parse($"{(num - 1) / 2}"));
        }

        private int ILeftChild(int num)
        {
            return (2 * num) + 1;
        }

        private int IRightChild(int num)
        {
            return (2 * num) + 2;
        }

    }
}
