using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SortingAlgorithmLibrary.Extensions
{
    public static class JsonToTuple
    {
        public static (int, double, string) ConvertToTuple(this JsonElement element)
        {
            int.TryParse(element[1].GetString(), out int arg1);
            double.TryParse(element[0].GetString().Replace("px", ""), out double arg2);
            string arg3 = element[2].GetString();
            return (arg1, arg2, arg3);
        }
    }
}
