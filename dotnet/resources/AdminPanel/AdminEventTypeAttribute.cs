using System;

namespace AdminPanel
{
    internal class AdminEventTypeAttribute : Attribute
    {
        public string Type { get; }

        public AdminEventTypeAttribute(string type) => Type = type;
    }
}