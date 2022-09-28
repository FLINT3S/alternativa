using System;
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;

namespace LocationProvider
{
    internal class Dimension
    {
        public Dimension(uint id)
        {
            DimensionId = id;
            CreatedAt = DateTime.Now;
            DimensionProvider.TakeDimension(this);
        }

        private uint DimensionId { get; }

        public List<Player> Players => NAPI.Pools.GetAllPlayers().Where(p => p.Dimension == DimensionId).ToList();

        public DateTime CreatedAt { get; }

        public static implicit operator uint(Dimension dimension) => dimension.DimensionId;
    }
}