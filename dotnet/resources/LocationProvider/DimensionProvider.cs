using System;
using System.Collections.Generic;
using System.Linq;

namespace LocationProvider
{
    public static class DimensionProvider
    {
        public const uint CommonDimension = 0U; 
        
        private static readonly List<Dimension> BusyDimensions = new List<Dimension>();

        private static void TakeDimension(Dimension dimension) =>
            BusyDimensions.Add(dimension);

        public static uint GetFreeDimension()
        {
            for (uint i = 1; i < uint.MaxValue; i++)
                if (!BusyDimensions.ContainsDimensionWithThisId(i))
                {
                    TakeDimension(new Dimension(i));
                    return i;
                }

            throw new InvalidOperationException("All dimensions are busy");
        }

        private static bool ContainsDimensionWithThisId(this IEnumerable<Dimension> dimensions, uint id) =>
            dimensions.Any(d => d == id);

        public static void ReleaseUnusedDimensions()
        {
            foreach (var dimension in GetUnusedDimensions())
                OnDimensionRelease(dimension);
        }

        private static IEnumerable<Dimension> GetUnusedDimensions() => BusyDimensions.Where(dimension =>
            dimension.Players.Count == 0 && DateTime.Now - dimension.CreatedAt == TimeSpan.FromMinutes(5)
        );

        private static void OnDimensionRelease(Dimension dimension) =>
            BusyDimensions.Remove(dimension);
    }
}