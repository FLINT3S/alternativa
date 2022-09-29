using System;
using System.Collections.Generic;
using System.Linq;

namespace DimensionProvider
{
    public static class DimensionManager
    {
        public const uint CommonDimension = 0U;
        
        private static readonly List<Dimension> BusyDimensions = new List<Dimension>();

        public static uint GetFreeDimension()
        {
            for (uint i = 1U; i < uint.MaxValue; i++)
                if (BusyDimensions.All(d => d != i))
                {
                    BusyDimensions.Add(new Dimension(i));
                    return i;
                }

            throw new InvalidOperationException("All dimensions are busy");
        }

        public static void ReleaseUnusedDimensions()
        {
            foreach (var dimension in GetUnusedDimensions())
                BusyDimensions.Remove(dimension);
        }

        private static IEnumerable<Dimension> GetUnusedDimensions() => BusyDimensions.Where(dimension =>
            dimension.Players.Count == 0 && DateTime.Now - dimension.CreatedAt == TimeSpan.FromMinutes(5)
        );
    }
}