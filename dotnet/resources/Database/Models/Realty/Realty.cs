using System;

namespace Database.Models.Realty
{
    public class Realty : AbstractModel
    {
        protected Realty()
        {
        }
        
        public Guid Id { get; protected set; }
        
        public RealtyPrototype Prototype { get; protected set; }
        
        public RealtyEntrance Entrance { get; protected set; }

        public Character Owner { get; protected set; }
    }
}