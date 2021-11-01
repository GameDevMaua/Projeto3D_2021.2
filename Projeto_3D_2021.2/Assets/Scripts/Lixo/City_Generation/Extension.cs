using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExtensionMethods
{
    public static class Extension
    {
        public static T GetRandom<T>(this IEnumerable<T> data)
        {
            var enumerable = data as T[] ?? data.ToArray();
            return enumerable.ElementAt(Random.Range(0, enumerable.Count()));
        }

        public static int FloorGridClamp(this float number, int gridSize)
        {
            return Mathf.FloorToInt(number / (float) gridSize) * gridSize;
        }
    }
}