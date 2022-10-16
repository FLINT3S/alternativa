using System;
using Database.Models.Realty;
using GTANetworkAPI;

namespace NAPIExtensions
{
    public static class ColShapeExtensions
    {
        public static ColShape CreateCircleColShape(this GTANetworkMethods.ColShape colShape, Vector3 position, uint dimension) =>
            colShape.CreatCircleColShape(position.X, position.Y, 1f, dimension);

        public static void SetInteraction(this ColShape shape, Action<Player, ColShape> action) =>
            shape.SetData(ColShapeConstants.Interaction, action);

        public static void Interaction(this ColShape shape, Player player)
        {
            if (shape.HasData(ColShapeConstants.Interaction)) 
                shape.GetData<Action<Player, ColShape>>(ColShapeConstants.Interaction)?.Invoke(player, shape);
        }

        public static RealtyEntrance? GetEntrance(this ColShape shape) =>
            shape.HasData(ColShapeConstants.Entrance) ?
                shape.GetData<RealtyEntrance>(ColShapeConstants.Entrance) :
                null;

        public static void SetEntrance(this ColShape shape, RealtyEntrance entrance) =>
            shape.SetData(ColShapeConstants.Entrance, entrance);

        public static Realty? GetRealty(this ColShape shape) =>
            shape.HasData(ColShapeConstants.Realty) ?
                shape.GetData<Realty>(ColShapeConstants.Realty) :
                null;

        public static void SetRealty(this ColShape shape, Realty entrance) =>
            shape.SetData(ColShapeConstants.Realty, entrance);
    }
}