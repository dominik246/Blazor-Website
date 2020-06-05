using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.Json;

namespace AlgorithmLibrary.Extensions
{
    public static class JsonElementToVector2
    {
        public static Vector2 ConvertToVector2(this JsonElement value)
        {
            Vector2 v2 = default;
            string[] tmp = value.GetString().Split(',', StringSplitOptions.RemoveEmptyEntries);
            float.TryParse(tmp[0], out v2.X);
            float.TryParse(tmp[1], out v2.Y);
            return v2;
        }
    }
}
