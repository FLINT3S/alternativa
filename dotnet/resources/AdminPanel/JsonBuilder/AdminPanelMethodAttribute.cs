using System;

namespace AdminPanel.JsonBuilder
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class AdminPanelMethodAttribute : Attribute
    {
        public string Category { get; }

        public bool IsReturnValue { get; }

        public AdminPanelMethodAttribute(string category, bool isReturnValue = false)
        {
            Category = category;
            IsReturnValue = isReturnValue;
        }
    }
}