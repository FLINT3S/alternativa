using System;
using System.Diagnostics.CodeAnalysis;
using GTANetworkAPI;

namespace Database.Models.RealEstate
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public abstract class AbstractRoom : AbstractModel
    {
        protected AbstractRoom()
        {
        }
        
        public Guid Id { get; protected set; }
        
        public Vector3 Entrance { get; protected set; }
        
        public Vector3 Exit { get; protected set; }
        
        public Vector3 Interior { get; protected set; }
    }
}