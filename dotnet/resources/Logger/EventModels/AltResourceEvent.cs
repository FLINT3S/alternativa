namespace Logger.EventModels
{
    public class AltResourceEvent : AltAbstractEvent
    {
        public AltResourceEvent(object module, ResourceEventType eventType, string eventDescription) :
            base($"logs/resources/{module.GetType().Name.ToLower()}.log", module,
                eventType.ToString(), eventDescription)
        {
        }

        public AltResourceEvent(object module, ResourceEventType eventType) : this(module, eventType, GetEventDescription(eventType, module))
        {
        }

        private static string GetEventDescription(ResourceEventType eventType, object module)
        {
            string resourceName = module.GetType().Name;
            return eventType switch
            {
                ResourceEventType.Started => $"Resource {resourceName} has been started",
                ResourceEventType.Shutdown => $"Resource {resourceName} shutdown",
                ResourceEventType.Error => $"Error occured in resource {resourceName}",
                _ => ""
            };
        }
    }
}