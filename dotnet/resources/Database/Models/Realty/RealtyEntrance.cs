using System;
using System.Collections.Generic;
using GTANetworkAPI;

namespace Database.Models.Realty
{
    public class RealtyEntrance : AbstractModel
    {
        protected RealtyEntrance() {}
        
        public Guid Id { get; protected set; }
        
        public Vector3 Position { get; protected set; }

        public List<Realty> Realties { get; } = new List<Realty>();
    }
}