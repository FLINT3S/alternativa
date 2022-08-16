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
        
        # region To Client Events
        public const string NeedLoginToClient = "CEF:CLIENT:Authorization:NeedLogin";
        public const string FirstEntryToClient = "CEF:CLIENT:Authorization:FirstEntry";
        public const string LoginSuccessToClient = "CEF:CLIENT:Authorization:LoginSuccess";
        # endregion
        
        # region To CEF events
        public const string FirstConnectionToCef = "FirstConnection";
        public const string LoginFailureToCef = "LoginFailure";
        #endregion
    }
}