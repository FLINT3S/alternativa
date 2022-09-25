using System;
using GTANetworkAPI;

namespace Database.Models.RealEstate
{
    public abstract class AbstractRealEstate : AbstractModel
    {
        protected AbstractRealEstate()
        {
        }
        
        public Guid Id { get; protected set; }
        
        public long Cost { get; protected set; } 
        
        public Character Owner { get; protected set; }
        
        public Vector3 Entrance { get; protected set; }
    }
}