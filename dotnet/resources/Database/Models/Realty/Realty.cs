using System;

namespace Database.Models.Realty
{
    public class Realty : AbstractModel
    {
        protected Realty()
        {
        }

        public Realty(RealtyPrototype prototype, RealtyEntrance entrance, Character owner)
        {
            Prototype = prototype;
            Entrance = entrance;
            Owner = owner;
        }

        public RealtyPrototype Prototype { get; protected set; }
        
        public RealtyEntrance Entrance { get; protected set; }

        public Character Owner { get; protected set; }
    }
}