/*
 * wiki: https://www.notion.so/AltAbstractResource-AbstractEvents-65bd6dfdbf2e48b9bd3295ded2e9cc28
 */

namespace AbstractResource
{
    public abstract class AltAbstractResourceEvents
    {
        public string ResourceName;

        public AltAbstractResourceEvents()
        {
            ResourceName = GetType().Name.Replace("Events", "");
        }

        public static EventString.EventString GetEs(string eventString) => new EventString.EventString(eventString);
    }
}