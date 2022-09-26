using System;

namespace AdminPanel
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class AdminEventTypeAttribute : Attribute
    {
        public string Type { get; }

        public AdminEventTypeAttribute(string type) => Type = type;
    }
}