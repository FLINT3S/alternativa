using System.Linq;

/*
 * wiki: https://www.notion.so/EventString-873f558c7ae64d1986965dc24377c894
 */

namespace AbstractResource
{
    public class EventString
    {
        #region FromStringConstructor

        public EventString(string eventString)
        {
            String = eventString;
            From = eventString.Split(':')[0];
            To = eventString.Split(':')[1];
            Module = eventString.Split(':')[2];
            Event = eventString.Split(':')[3..].Aggregate((s1, s2) => s1 + s2);
        }

        #endregion

        public string From { get; }

        public string To { get; }

        public string Module { get; }

        public string Event { get; }

        private string String { get; }

        public override string ToString() => String;

        #region FromStringsCtors

        public EventString(string from, string to, string module, string @event)
        {
            From = from;
            To = to;
            Module = module;
            Event = @event;
            String = $"{From}:{To}:{Module}:{Event}";
        }

        public EventString(string from, string module, string @event) : this(from, "SERVER", module, @event)
        {
        }

        public EventString(string module, string @event) : this("SERVER", "CLIENT", module, @event)
        {
        }

        #endregion

        #region ByObjectCtors

        public EventString(string from, string to, object module, string @event) : this(
            from,
            to,
            module.GetType().Name,
            @event
        )
        {
        }

        public EventString(string from, object module, string @event) : this(from, "SERVER", module, @event)
        {
        }

        public EventString(object module, string @event) : this("SERVER", "CLIENT", module, @event)
        {
        }

        #endregion
    }
}