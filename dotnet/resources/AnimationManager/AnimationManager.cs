using AbstractResource;
using GTANetworkAPI;
using NAPIExtensions;

namespace AnimationManager
{
    public class AnimationManager : AltAbstractResource
    {
        [Command("playanim")]
        [RemoteEvent("CLIENT:SERVER:Animations:PlayAnimation")]
        public void OnPlayAnimation(Player player, string dict, string name, int flag) =>
            PlayAnimation(player, dict, name, flag);

        [Command("stopanim")]
        [RemoteEvent("CLIENT:SERVER:Animations:StopAnimation")]
        public void OnStopAnimation(Player player) =>
            StopAnimation(player);

        public static void PlayAnimation(Player player, string dict, string name, int flag)
        {
            player.SetData(PlayerConstants.AnimationPlaying, true);
            player.SetSharedData(PlayerConstants.AnimationPlaying, true);
            player.PlayAnimation(dict, name, flag);
        }

        public static void StopAnimation(Player player)
        {
            if (!player.HasData(PlayerConstants.AnimationPlaying)) return;

            player.StopAnimation();
            player.ResetData(PlayerConstants.AnimationPlaying);
            player.ResetSharedData(PlayerConstants.AnimationPlaying);
        }
    }
}
