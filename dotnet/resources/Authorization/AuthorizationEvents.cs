using AbstractResource;

/*
 * wiki: https://www.notion.so/Authorization-44a4b5377f2848c59d1772d89dde092d
 */

namespace Authorization
{
    public abstract class AuthorizationEvents : AltAbstractResourceEvents
    {
        public const string LoginSubmitFromCef = "CEF:SERVER:Authorization:LoginSubmit";
        public const string RegisterSubmitFromCef = "CEF:SERVER:Authorization:RegisterSubmit";

        public const string FirstConnectionToCef = "FirstConnection";
            
        public const string LoginSuccessToCef = "LoginSuccess";
        public const string LoginFailureToCef = "LoginFailure";
    }
}