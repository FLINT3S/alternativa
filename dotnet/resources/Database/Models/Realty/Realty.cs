using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Castle.Core.Internal;
using DimensionProvider;
using GTANetworkAPI;

namespace Database.Models.Realty
{
    public class Realty : AbstractModel
    {
        private readonly List<Player> visitors = new List<Player>();

        private ColShape exit;

        private uint? dimension;

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

        [NotMapped] public bool IsEmpty => visitors.IsNullOrEmpty();

        public void SetExit(ColShape shape)
        {
            exit = shape;
            dimension = shape.Dimension;
        }

        public void OnPlayerEntrance(Player player)
        {
            visitors.Add(player);
            
            player.Position = Prototype.Interior.Entrance;
            player.Dimension = dimension!.Value;
        }

        public void OnPlayerExit(Player player)
        {
            visitors.Remove(player);
            if (IsEmpty)
                CleanRoom();

            player.Dimension = DimensionManager.CommonDimension;
            player.Position = Entrance.Position;
        }

        private void CleanRoom()
        {
            NAPI.ColShape.DeleteColShape(exit);
            dimension = null;
            visitors.Clear();
        }
    }
}