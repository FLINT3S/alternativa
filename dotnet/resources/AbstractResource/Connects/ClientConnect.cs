namespace AbstractResource.Connects
{
    public class ClientConnect : AbstractConnect
    {
        public ClientConnect(object module) : base(module)
        {
        }

        protected override string Receiver => "CLIENT";
    }
}