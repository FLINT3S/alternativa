using DimensionProvider;
using GTANetworkAPI;

namespace Database.Models.Realty
{
    public class Realty : AbstractModel
    {
        private uint? dimension = null;
        
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

        public void OnPlayerEntrance(Player player)
        {
            dimension ??= DimensionManager.GetFreeDimension();
            
            player.Position = Prototype.Interior.Entrance;
            player.Dimension = dimension.Value;
        }
    }
}