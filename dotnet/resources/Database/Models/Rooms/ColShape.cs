using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GTANetworkAPI;

namespace Database.Models.Rooms
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public partial class ColShape : AbstractModel
    {
        // ReSharper disable once EmptyConstructor
        protected ColShape()
        {
        }
        
        public Guid Id { get; private set; }
        
        public Vector3 Center { get; private set; }
        
        public float Radius { get; private set; }

        public List<AbstractRoom> Rooms { get; } = new List<AbstractRoom>();
    }
}