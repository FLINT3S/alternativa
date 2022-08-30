namespace Logger.EventModels
{
    public abstract class AltAbstractEvent
    {
        protected AltAbstractEvent(string destination, object module, string eventName, string eventDescription)
        {
            Destination = destination;
            Module = module.GetType().FullName!;
            EventName = eventName;
            EventDescription = eventDescription;
        }

        public string Destination { get; }

        private string Module { get; }

        private string EventInstance => GetType().Name;

        private string EventName { get; }

        private string EventDescription { get; }

        public virtual object LockObj => new object();

        public override string ToString() => $"<{EventInstance}>: {Module} > {EventName} - {EventDescription}";
    }
}