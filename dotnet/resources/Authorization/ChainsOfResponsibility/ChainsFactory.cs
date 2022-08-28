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
            var emailTakenChecker = new RegistrationHandlers.EmailTakenChecker(cefConnect, successRegistrationHandler);
            var usernameTakenHandler = new RegistrationHandlers.UsernameTakenChecker(cefConnect, emailTakenChecker);
            var hasAccountHandler = new RegistrationHandlers.ExistAccountChecker(cefConnect, usernameTakenHandler);
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