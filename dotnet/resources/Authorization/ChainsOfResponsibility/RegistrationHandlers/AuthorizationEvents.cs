namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    internal static class AuthorizationEvents
    {
        public const string RegisterSuccessToClient = "SERVER:CLIENT:Authorization:RegisterSuccess";
        
        public const string RegisterFailureToCef = "SERVER:CEF:Authorization:RegisterFailure";
    }
}