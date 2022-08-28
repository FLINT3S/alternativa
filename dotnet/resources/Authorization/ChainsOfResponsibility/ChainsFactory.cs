using System;
using AbstractResource;

namespace Authorization.ChainsOfResponsibility
{
    public static class ChainsFactory
    {
        public static void SetChain(ref PlayerConnectedHandlers.AbstractHandler field)
        {
            if (field == null) throw new ArgumentNullException(nameof(field));
            var loginStatusSender = new PlayerConnectedHandlers.LoginStatusSender();
            var temporaryBansChecker = new PlayerConnectedHandlers.TemporaryBanChecker(loginStatusSender);
            var permanentBansChecker = new PlayerConnectedHandlers.PermanentBanChecker(temporaryBansChecker);
            var existAccountChecker = new PlayerConnectedHandlers.ExistAccountChecker(permanentBansChecker);
            var hwidBansChecker = new PlayerConnectedHandlers.HwidBansChecker(existAccountChecker);
            field = hwidBansChecker;
        }

        public static void SetChain(ref RegistrationHandlers.AbstractHandler field, CefConnect cefConnect)
        {
            if (field == null) throw new ArgumentNullException(nameof(field));
            var successRegistrationHandler = new RegistrationHandlers.SuccessRegistrationHandler(cefConnect);
            var emailTakenChecker = new RegistrationHandlers.EmailTakenChecker(cefConnect, successRegistrationHandler);
            var usernameTakenHandler = new RegistrationHandlers.UsernameTakenChecker(cefConnect, emailTakenChecker);
            var hasAccountHandler = new RegistrationHandlers.ExistAccountChecker(cefConnect, usernameTakenHandler);
            field = hasAccountHandler;
        }

        public static void SetChain(ref LoginHandlers.AbstractHandler field, CefConnect cefConnect)
        {
            if (field == null) throw new ArgumentNullException(nameof(field));
            var successLoginHandler = new LoginHandlers.SuccessLoginHandler(cefConnect);
            var doubleLoginChecker = new LoginHandlers.DoubleLoginChecker(cefConnect, successLoginHandler);
            var passwordHandler = new LoginHandlers.PasswordChecker(cefConnect, doubleLoginChecker);
            var loginHandler = new LoginHandlers.LoginChecker(cefConnect, passwordHandler);
            var existAccountChecker = new LoginHandlers.ExistAccountChecker(cefConnect, loginHandler);
            field = existAccountChecker;
        }
    }
}