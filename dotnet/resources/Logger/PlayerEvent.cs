namespace Logger;

public class PlayerEvent : EventModel
{
    public PlayerEvent(object playerNickname, string module, string eventName, string eventDescription) : base($"logs/players/{playerNickname}.log", module, eventName, eventDescription)
    {
    }
}