using System;
using System.Diagnostics.CodeAnalysis;
using GTANetworkAPI;

namespace Database.Models
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public partial class CharacterSpawnData
    {
        public Guid Id { get; protected set; }
        
        public Character Owner { get; protected set; }
        
        public Guid OwnerId { get; protected set; }

        public int Armor { get; protected set; }

        public int Health { get; protected set; } = 100;
        
        public Vector3 Position { get; set; }
        
        public float Heading { get; protected set; }
    }
}