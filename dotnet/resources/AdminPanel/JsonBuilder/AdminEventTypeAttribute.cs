using System;

namespace AdminPanel.JsonBuilder
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class AdminEventTypeAttribute : Attribute
    {
        public string Type { get; }

        public AdminEventTypeAttribute(string type)
        {
            Type = type;
        }
    }
}