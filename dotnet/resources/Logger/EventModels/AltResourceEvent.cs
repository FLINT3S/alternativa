namespace Logger.EventModels
{
    public class AltResourceEvent : AltAbstractEvent
    {
        public AltResourceEvent(object module, ResourceEventType eventType, string eventDescription) :
            base($"logs/resources/{module.GetType().Name.ToLower()}.log", module,
                eventType.ToString(), eventDescription)
        {
        }

        public AltResourceEvent(object module, ResourceEventType eventType) :
            base($"logs/resources/{module.GetType().Name.ToLower()}.log", module,
                eventType.ToString(), GetEventDescription(eventType, module))
        {
        }

        private static string GetEventDescription(ResourceEventType eventType, object module)
        {
            string eventDescription = "";
            var resourceName = module.GetType().Name;

            switch (eventType)
            {
                case ResourceEventType.Started:
                    eventDescription = $"Resource {resourceName} has been started";
                    break;
                case ResourceEventType.Shutdown:
                    eventDescription = $"Resource {resourceName} shutdown";
                    break;
                case ResourceEventType.Error:
                    eventDescription = $"Error occured in resource {resourceName}";
                    break;
            }

            return eventDescription;
        }
    }
}