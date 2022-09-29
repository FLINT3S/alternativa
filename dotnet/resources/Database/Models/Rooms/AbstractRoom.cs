using System;
using System.Diagnostics.CodeAnalysis;
using GTANetworkAPI;

namespace Database.Models.Rooms
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public abstract class AbstractRoom : AbstractModel
    {
        // ReSharper disable once EmptyConstructor
        protected AbstractRoom()
        {
        }
        
        public Guid Id { get; protected set; }
        
        public ColShape Entrance { get; protected set; }
        
        public ColShape Exit { get; protected set; }
        
        public Vector3 Interior { get; protected set; }
    }
}