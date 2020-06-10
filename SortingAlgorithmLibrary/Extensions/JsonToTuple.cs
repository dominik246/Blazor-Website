using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SortingAlgorithmLibrary.Extensions
{
    public static class JsonToTuple
    {
        public static (int, string, double, string) ConvertToTuple(this JsonElement element)
        {
            // list has to be [index, text, height, iterateOver]
            int.TryParse(element[0].GetString(), out int arg1);
            string arg2 = element[1].GetString();
            double.TryParse(element[2].GetString().Replace("px", ""), out double arg3);
            string arg4 = element[3].GetString();
            return (arg1, arg2, arg3, arg4);
        }
    }
}
