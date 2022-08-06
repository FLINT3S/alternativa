namespace Logger.EventModels
{
    public abstract class AltAbstractEvent
    {
        protected AltAbstractEvent(string destination, string module, string eventName, string eventDescription)
        {
            Destination = destination;
            Module = module;
            EventName = eventName;
            EventDescription = eventDescription;
        }

        public string Destination { get; }

        private string Module { get; }

        private string EventInstance => GetType().FullName!;

        private string EventName { get; }

        private string EventDescription { get; }

        public override string ToString() => $"<{EventInstance}>: {Module} > {EventName} - {EventDescription}";
    }
}