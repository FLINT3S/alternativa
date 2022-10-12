using System;

namespace Database.Models.Realty
{
    public class RealtyPrototype : AbstractModel
    {
        protected RealtyPrototype() {}
        
        public Guid Id { get; protected set; }
        
        public Interior Interior { get; protected set; }
        
        public RealtyType Type { get; protected set; }
        
        public RealtyPriceSegment PriceSegment { get; protected set; }
        
        public long GovernmentPrice { get; protected set; }
        
        public byte ParkingPlaces { get; protected set; }
    }
}