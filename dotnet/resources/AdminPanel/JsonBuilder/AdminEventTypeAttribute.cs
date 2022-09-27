using System;

namespace AdminPanel.JsonBuilder
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class AdminEventTypeAttribute : Attribute
    {
        public string Category { get; }

        public AdminEventTypeAttribute(string category)
        {
            Category = category;
        }
    }
}