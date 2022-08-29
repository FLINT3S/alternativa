namespace AbstractResource.Connects
{
    public class CefConnect : AbstractConnect
    {
        public CefConnect(object module) : base(module)
        {
        }

        protected override string Receiver => "CEF";
    }
}