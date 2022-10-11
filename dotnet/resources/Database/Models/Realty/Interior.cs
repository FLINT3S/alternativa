using System;
using GTANetworkAPI;

namespace Database.Models.Realty
{
    public class Interior : AbstractModel
    {
        protected Interior()
        {
        }
        
        public Guid Id { get; protected set; }
        
        public Vector3 Entrance { get; protected set; }
        
        public Vector3 Exit { get; protected set; }
    }
}