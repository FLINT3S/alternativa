using System;

namespace AdminPanel.JsonBuilder
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class AdminPanelMethodAttribute : Attribute
    {
        public string Category { get; }

        public bool IsReturnsValue { get; }

        public AdminPanelMethodAttribute(string category, bool isReturnsValue = false)
        {
            Category = category;
            IsReturnsValue = isReturnsValue;
        }
    }
}