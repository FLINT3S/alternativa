using System;
using System.Collections.Generic;
using GTANetworkAPI;
using ColShape = GTANetworkMethods.ColShape;

namespace Database.Models.Realty
{
    public class RealtyEntrance
    {
        private ColShape colShape;
        
        protected RealtyEntrance() {}
        
        public Guid Id { get; protected set; }
        
        public Vector3 Position { get; protected set; }

        public List<Realty> Realties { get; } = new List<Realty>();
    }
}