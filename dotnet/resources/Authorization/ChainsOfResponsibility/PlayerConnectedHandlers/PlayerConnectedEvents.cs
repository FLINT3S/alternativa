namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal static class AuthorizationEvents
    {
        public const string FirstConnection = "FirstConnection";

        public const string NeedLogin = "NeedLogin";

        public const string TemporaryBanned = "TempBan";

        public const string PermanentlyBanned = "PermanentBan";

        public const string LoginSuccess = "LoginSuccess";
    }
}