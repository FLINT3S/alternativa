using System;
using System.Collections.Generic;
using GTANetworkAPI;

namespace Database.Models.Realty
{
    public class RealtyEntrance : AbstractModel
    {
        protected RealtyEntrance() {}
        
        public RealtyEntrance(Vector3 position, RealtyEntranceType type)
        {
            Position = position;
            Type = type;
        }
        
        public Vector3 Position { get; protected set; }
        
        /*
         * Тип входа (дома). Используется для разграниения создания обычных и многоквартирных домов
         */
        public RealtyEntranceType Type { get; protected set; }

        public List<Realty> Realties { get; } = new List<Realty>();
    }
}