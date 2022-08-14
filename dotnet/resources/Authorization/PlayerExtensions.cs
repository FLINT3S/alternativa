using GTANetworkAPI;

namespace Authorization
{
    public static class PlayerExtensions
    {
        public static string GetPlayerDataString(this Player player)
        {
            return $"New player connected:\n" +
                   $"name: {player.Name}\n" +
                   $"socialClubId: {player.SocialClubId}\n" +
                   $"IP: {player.Address}\n" +
                   $"HWID: {player.Serial}\n" +
                   $"socialClubName: {player.SocialClubName}\n" +
                   $"===========================================================";
        }
    }
}