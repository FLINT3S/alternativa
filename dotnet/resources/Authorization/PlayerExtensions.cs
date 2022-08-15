using GTANetworkAPI;

namespace Authorization
{
    public static class PlayerExtensions
    {
        public static string GetPlayerDataString(this Player player)
        {
            string response = "New player connected:\n";
            response += $"name: {player.Name}\n";
            response += $"socialClubId: {player.SocialClubId}\n";
            response += $"IP: {player.Address}";
            response += $"HWID: {player.Serial}\n";
            response += $"socialClubName: {player.SocialClubName}\n";
            response += "===========================================================";
            return response;
        }
    }
}