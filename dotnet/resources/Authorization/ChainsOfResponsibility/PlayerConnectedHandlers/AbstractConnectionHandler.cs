using AbstractResource.Connects;
using GTANetworkAPI;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal abstract class AbstractConnectionHandler : AbstractHandler
    {
        protected AbstractConnectionHandler(ClientConnect clientConnect, AbstractConnectionHandler? next)
        {
            ClientConnect = clientConnect;
            Next = next;
        }

        protected ClientConnect ClientConnect { get; }

        private AbstractConnectionHandler? Next { get; }

        protected override string EventName => "ConnectFailure";

        public void Handle(Player player)
        {
            if (CanHandle(player))
                _Handle(player);
            else
                Next!.Handle(player);
        }

        protected abstract bool CanHandle(Player player);

        protected abstract void _Handle(Player player);

        public static AbstractConnectionHandler GetChain(ClientConnect clientConnect)
        {
            var loginStatusSender = new LoginStatusSender(clientConnect);
            var temporaryBansChecker = new TemporaryBanChecker(clientConnect, loginStatusSender);
            var permanentBansChecker = new PermanentBanChecker(clientConnect, temporaryBansChecker);
            var existAccountChecker = new ExistAccountChecker(clientConnect, permanentBansChecker);
            var hwidBansChecker = new HwidBansChecker(clientConnect, existAccountChecker);
            return hwidBansChecker;
        }
    }
}