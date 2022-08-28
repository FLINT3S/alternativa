namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal static class AuthorizationEvents
    {
        public const string PermanentlyBanned = "SERVER:CLIENT:Authorization:PermanentBan";

        public const string TemporaryBanned = "SERVER:CLIENT:Authorization:TempBan";

        public const string FirstConnectionToClient = "SERVER:CLIENT:Authorization:FirstConnection";

        public const string NeedLoginToClient = "SERVER:CLIENT:Authorization:NeedLogin";

        public const string LoginSuccessToClient = "SERVER:CLIENT:Authorization:LoginSuccess";
        
    }
}