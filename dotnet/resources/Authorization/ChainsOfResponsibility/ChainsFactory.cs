using AbstractResource;

namespace Authorization.ChainsOfResponsibility
{
    public static class ChainsFactory
    {
        public static PlayerConnectedHandlers.AbstractHandler GetConnectChain()
        {
            var loginStatusSender = new PlayerConnectedHandlers.LoginStatusSender();
            var temporaryBansChecker = new PlayerConnectedHandlers.TemporaryBanChecker(loginStatusSender);
            var permanentBansChecker = new PlayerConnectedHandlers.PermanentBanChecker(temporaryBansChecker);
            var existAccountChecker = new PlayerConnectedHandlers.ExistAccountChecker(permanentBansChecker);
            var hwidBansChecker = new PlayerConnectedHandlers.HwidBansChecker(existAccountChecker);
            return hwidBansChecker;
        }

        public static RegistrationHandlers.AbstractHandler GetRegistrationChain(CefConnect cefConnect)
        {
            var successRegistrationHandler = new RegistrationHandlers.SuccessRegistrationHandler(cefConnect);
            var usernameTakenHandler = new RegistrationHandlers.UsernameTakenChecker(cefConnect, successRegistrationHandler);
            var hasAccountHandler = new RegistrationHandlers.HasAccountChecker(cefConnect, usernameTakenHandler);
            return hasAccountHandler;
        }

        public static LoginHandlers.AbstractHandler GetLoginChain(CefConnect cefConnect)
        {
            var successLoginHandler = new LoginHandlers.SuccessLoginHandler(cefConnect);
            var doubleLoginChecker = new LoginHandlers.DoubleLoginChecker(cefConnect, successLoginHandler);
            var passwordHandler = new LoginHandlers.PasswordChecker(cefConnect, doubleLoginChecker);
            var loginHandler = new LoginHandlers.LoginChecker(cefConnect, passwordHandler);
            return loginHandler;
        }
    }
}