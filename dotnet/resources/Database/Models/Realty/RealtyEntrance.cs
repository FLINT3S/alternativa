﻿using System;
using System.Collections.Generic;
using GTANetworkAPI;

namespace Database.Models.Realty
{
    public class RealtyEntrance
    {
        protected RealtyEntrance() {}
        
        public Guid Id { get; protected set; }
        
        public Vector3 Entrance { get; protected set; }

        public List<Realty> Realties { get; } = new List<Realty>();
    }
}