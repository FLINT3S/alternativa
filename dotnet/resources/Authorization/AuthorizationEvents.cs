/*
 * wiki: https://www.notion.so/Authorization-44a4b5377f2848c59d1772d89dde092d
 */

namespace Authorization
{
    internal static class AuthorizationEvents
    {
        public const string LoginSubmitFromCef = "CEF:SERVER:Authorization:LoginSubmit";

        public const string RegisterSubmitFromCef = "CEF:SERVER:Authorization:RegisterSubmit";

        public const string PlayerReadyFromClient = "CLIENT:SERVER:Authorization:PlayerReady";

        #region Social Club Id Chek Events

        public const string CheckSocialClubIdFromCef = "CEF:SERVER:Authorization:CheckSocialClubId";

        public const string IsSocialClubIdTakenToCef = "IsSocialClubIdTaken";

        #endregion

        #region Username Check Events

        public const string CheckUsernameFromCef = "CEF:SERVER:Authorization:CheckUsername";

        public const string IsUsernameTakenToCef = "IsUsernameTaken";

        #endregion

        #region Email Check Events

        public const string CheckEmailFromCef = "CEF:SERVER:Authorization:CheckEmail";

        public const string IsEmailTakenToCef = "IsEmailTaken";

        #endregion
    }
}