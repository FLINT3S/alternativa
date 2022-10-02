using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Rooms
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public partial class RoomColShape : ColShape
    {
        // ReSharper disable once EmptyConstructor
        protected RoomColShape()
        {
        }
        
        public bool IsInternal { get; private set; } 

        public List<AbstractRoom> Rooms { get; } = new List<AbstractRoom>();
        
        public AbstractRoom Owner { get; private set; }
        
        public Guid OwnerId { get; private set; }
    }
}