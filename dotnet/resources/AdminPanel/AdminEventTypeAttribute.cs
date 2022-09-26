using System;

namespace AdminPanel
{
    public class AdminEventTypeAttribute : Attribute
    {
        public string Type { get; }

        public AdminEventTypeAttribute(string type)
        {
            Type = type;
        }
    }
}