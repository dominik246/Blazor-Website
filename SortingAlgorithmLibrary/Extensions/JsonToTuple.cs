using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SortingAlgorithmLibrary.Extensions
{
    public static class JsonToTuple
    {
        public static (int, string, double, double[], string) ConvertToTuple(this JsonElement element)
        {
            // list has to be [index, text, height, [h, s, v]]
            int.TryParse(element[0].GetString(), out int arg1);
            string arg2 = element[1].GetString();
            double.TryParse(element[2].GetString().Replace("px", ""), out double arg3);
            double[] arg4 = new double[]
            {
                element[3][0].GetDouble(),
                element[3][1].GetDouble(),
                element[3][2].GetDouble()
            };
            string arg5 = element[4].GetString();
            return (arg1, arg2, arg3, arg4, arg5);
        }
    }
}
