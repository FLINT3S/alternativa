using System;
using System.ComponentModel.DataAnnotations.Schema;
using GTANetworkAPI;

namespace Database.Models.Realty
{
    public class Realty
    {
        protected Realty() {}
        
        public Guid Id { get; protected set; }
        
        public RealtyPrototype Prototype { get; protected set; }
        
        public Vector3 EntrancePosition { get; protected set; }

        public Character Owner { get; protected set; }
        
        [NotMapped] public GTANetworkMethods.ColShape Entrance { get; protected set; }
        
        [NotMapped] public GTANetworkMethods.ColShape Exit { get; protected set; }
    }
}