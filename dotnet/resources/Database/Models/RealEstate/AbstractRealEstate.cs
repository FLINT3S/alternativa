using System;
using System.Diagnostics.CodeAnalysis;
using GTANetworkAPI;

namespace Database.Models.RealEstate
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public abstract class AbstractRealEstate : AbstractModel
    {
        // ReSharper disable once EmptyConstructor
        protected AbstractRealEstate()
        {
        }
        
        public Guid Id { get; protected set; }
        
        public long Cost { get; protected set; } 
        
        public Character Owner { get; protected set; }
        
        public Vector3 Entrance { get; protected set; }
        
        public Vector3 Interior { get; protected set; }
    }
}