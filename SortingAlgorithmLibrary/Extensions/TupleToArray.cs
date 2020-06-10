using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithmLibrary.Extensions
{
    public static class TupleToArray
    {
        public static object[] ConvertToArray(this (object, object, object) tuple)
        {
            return new object[] { tuple.Item1, tuple.Item2, tuple.Item3 };
        }
    }
}
