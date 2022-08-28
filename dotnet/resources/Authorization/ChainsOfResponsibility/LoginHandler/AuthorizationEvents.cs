namespace Authorization.ChainsOfResponsibility.LoginHandler
{
    internal static class AuthorizationEvents
    {
        public const string LoginFailureToCef = "SERVER:CEF:Authorization:LoginFailure";
        
        public const string LoginSuccessToClient = "SERVER:CLIENT:Authorization:LoginSuccess";
    }
}