using AbstractResource;

/*
 * wiki: https://www.notion.so/Authorization-44a4b5377f2848c59d1772d89dde092d
 */

namespace Authorization
{
    public class AuthorizationEvents : AltAbstractResourceEvents
    {
        public const string LoginAttemptFromCef = "CEF:SERVER:Authorization:LoginSubmit";
    }
}