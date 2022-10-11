using System;
using GTANetworkAPI;

namespace NAPIExtensions
{
    public static class ColShapeExtensions
    {
        public static void SetInteraction(this ColShape shape, Action<Player, ColShape> action)
        {
            shape.SetData<Action<Player,ColShape>>("colShapeInteraction", action);
        }
        
        public static void Interaction(this ColShape shape, Player player)
        {
            if (shape.HasData("colShapeInteraction")) shape
                .GetData<Action<Player, ColShape>>("colShapeInteraction")
                ?.Invoke(player, shape);
        }
    }
}