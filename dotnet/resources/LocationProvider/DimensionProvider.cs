using System;
using System.Collections.Generic;

namespace LocationProvider
{
    public class DimensionProvider
    {
        private static readonly List<uint> BusyDimensions = new List<uint>();

        public static uint GetFreeDimension()
        {
            for (uint i = 0; i < uint.MaxValue; i++)
                if (!BusyDimensions.Contains(i))
                {
                    BusyDimensions.Add(i);
                    return i;
                }

            throw new InvalidOperationException("All dimensions are busy");
        }

        public static void OnDimensionRelease(uint dimension) => BusyDimensions.Remove(dimension);
    }
}