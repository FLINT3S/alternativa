using System;
using System.Diagnostics.CodeAnalysis;
using GTANetworkAPI;

namespace Database.Models
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public partial class ColShape : AbstractModel
    {
        protected ColShape()
        {
        }
        
        public Guid Id { get; private set; }
        
        public Vector3 Center { get; private set; }
        
        public float Radius { get; private set; }
    }
}