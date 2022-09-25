using AbstractResource;
using GTANetworkAPI;
using NAPIExtensions;

namespace AnimationManager
{
    public abstract class AnimationManager : AltAbstractResource
    {
        [Command("playanim")]
        [RemoteEvent(AnimationManagerEvents.PlayAnimationFromClient)]
        public static void PlayAnimation(Player player, string dict, string name, int flag)
        {
            player.SetData(PlayerConstants.AnimationPlaying, true);
            player.SetSharedData(PlayerConstants.AnimationPlaying, true);
            player.PlayAnimation(dict, name, flag);
        }

        [Command("stopanim")]
        [RemoteEvent(AnimationManagerEvents.StopAnimationFromClient)]
        public static void StopAnimation(Player player)
        {
            if (!player.HasData(PlayerConstants.AnimationPlaying)) return;

            player.StopAnimation();
            player.ResetData(PlayerConstants.AnimationPlaying);
            player.ResetSharedData(PlayerConstants.AnimationPlaying);
        }
    }
}