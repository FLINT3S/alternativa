using System;

namespace AbstractResource.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NeedAdminRightsAttribute : Attribute
    {
        public int Level { get; }

        public NeedAdminRightsAttribute(int level = 0)
        {
            Level = level;
        }
    }
}