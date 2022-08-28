using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    public abstract class AbstractHandler
    {
        private AbstractHandler? Next { get; }

        protected AbstractHandler(AbstractHandler? next)
        {
            Next = next;
        }

        public void Handle(Player player)
        {
            if (CanHandle(player))
                _Handle(player);
            else
                Next!.Handle(player);
        }

        protected abstract bool CanHandle(Player player);

        protected abstract void _Handle(Player player);

        public static AbstractHandler GetChain()
        {
            var loginStatusSender = new LoginStatusSender();
            var temporaryBansChecker = new TemporaryBanChecker(loginStatusSender);
            var permanentBansChecker = new PermanentBanChecker(temporaryBansChecker);
            var existAccountChecker = new ExistAccountChecker(permanentBansChecker);
            var hwidBansChecker = new HwidBansChecker(existAccountChecker);
            return hwidBansChecker;
        }
    }
}